rewriteIndirectRefs   "Smalltalk rewriteIndirectRefs"
	"For all classes, identify all methods with references to globals outside their direct access path.
	For each of these, call another method to rewrite the source with proper references."

	| cm lits envtForVar envt foundOne allClasses n |
	envtForVar _ Dictionary new.  "Dict of varName -> envt name"
	Smalltalk associationsDo:
		[:assn | (((envt _ assn value) isKindOf: Environment) and: [envt size < 500])
			ifTrue: [envt associationsDo:
						[:a | envtForVar at: a key put: assn key]]].

	"Allow compiler to compile refs to globals out of the direct reference path"
	Preferences enable: #lenientScopeForGlobals.

	allClasses _ OrderedCollection new.
	Smalltalk allClassesAnywhereDo: [:cls | allClasses addLast: cls].
	'Updating indirect global references in source code...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: allClasses size
		during:
		[:bar | n _ 0.
		allClasses do:
			[:cls | bar value: (n_ n+1).
			{ cls. cls class } do:
				[:cl | cl selectors do:
					[:sel | cm _ cl compiledMethodAt: sel.
					lits _ cm literals.
					foundOne _ false.
					lits do:
						[:lit | lit isVariableBinding ifTrue:
							[(lit value == cl or: [(cl bindingOf: lit key) notNil])
								ifFalse: [foundOne _ true]]].
					foundOne ifTrue:
						[self rewriteSourceForSelector: sel inClass: cl using: envtForVar]]].
			]].

	Preferences disable: #lenientScopeForGlobals.

