tallyIndirectRefs   "Smalltalk tallyIndirectRefs"
	"For all classes, tally the number of references to globals outside their inherited environment.  Then determine the 'closest' environment that resolves most of them.  If the closest environment is different from the one in whick the class currently resides, then enter the class name with the tallies of its references to all other environments.
	Return a triplet:
	A dictionary of all classes for which this is so, with those tallies,
	A dictionary giving the classes that would be happier in each of the other categories,
	A list of the variable names sorted by number of occurrences."

	| tallies refs cm lits envtForVar envt envtRefs allRefs newCategories cat allClasses n |
	envtForVar _ Dictionary new.  "Dict of varName -> envt name"
	allRefs _ Bag new.
	Smalltalk associationsDo:
		[:assn | (((envt _ assn value) isKindOf: Environment) and: [envt size < 500])
			ifTrue: [envt associationsDo:
						[:a | envtForVar at: a key put: assn key]]].

	tallies _ Dictionary new.
	allClasses _ OrderedCollection new.
	Smalltalk allClassesAnywhereDo: [:cls | allClasses addLast: cls].
	'Scanning methods with indirect global references...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: allClasses size
		during:
		[:bar | n _ 0.
		allClasses do:
			[:cls | bar value: (n_ n+1).
			refs _ Set new.
			{ cls. cls class } do:
			[:cl | cl selectors do:
				[:sel | cm _ cl compiledMethodAt: sel.
				lits _ cm literals.
				lits do:
					[:lit | lit isVariableBinding ifTrue:
						[(lit value == cl or: [cls canFindWithoutEnvironment: lit key])
							ifFalse: [refs add: lit key]]]]].
		envtRefs _ Bag new.
		refs asSet do:
			[:varName |
			envtRefs add: (envtForVar at: varName)
					withOccurrences: (refs occurrencesOf: varName).
			(envtRefs sortedCounts isEmpty or: [envtRefs sortedCounts first value == (Smalltalk keyAtValue: cls environment)])
				ifFalse: [allRefs add: varName withOccurrences: (refs occurrencesOf: varName).
						tallies at: cls name put: envtRefs sortedCounts.
						Transcript cr; print: envtRefs sortedCounts; endEntry]]]].

	newCategories _ Dictionary new.
	tallies associationsDo:
		[:assn | cat _ assn value first value.
		(newCategories includesKey: cat) ifFalse:
			[newCategories at: cat put: Array new].
		newCategories at: cat put: ((newCategories at: cat) copyWith: assn key)].
	^ { tallies. newCategories. allRefs sortedCounts }