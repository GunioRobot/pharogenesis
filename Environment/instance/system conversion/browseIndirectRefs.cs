browseIndirectRefs  "Smalltalk browseIndirectRefs"

	| cm lits browseList foundOne allClasses n |
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
						[:lit | lit class == Association ifTrue:
							[(lit value == cl or: [cl scopeHas: lit key ifTrue: [:ignored]])
								ifFalse: [foundOne _ true]]].
					foundOne ifTrue: [browseList add: cl name , ' ' , sel]]]]].

	Smalltalk browseMessageList: browseList asSortedCollection
		name: 'Indirect Global References' autoSelect: nil