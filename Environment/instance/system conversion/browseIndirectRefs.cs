browseIndirectRefs  "Smalltalk browseIndirectRefs"

	| cm lits browseList foundOne allClasses n |

	self flag: #mref.		"no senders at the moment. also no Environments at the moment"

	browseList _ OrderedCollection new.
	allClasses _ OrderedCollection new.
	Smalltalk allClassesAnywhereDo: [:cls | allClasses addLast: cls].
	'Locating methods with indirect global references...'
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
					foundOne ifTrue: [
						browseList add: (
							MethodReference new
								setStandardClass: cl 
								methodSymbol: sel
						)
					]]]]].

	self systemNavigation 
		browseMessageList: browseList asSortedCollection
		name: 'Indirect Global References'
		autoSelect: nil