allMethodsWithEncodingTag: encodingTag
	"Answer a SortedCollection of all the methods that implement the message 
	aSelector."

	| list adder num i |
	list _ Set new.
	adder _ [ :mrClass :mrSel |
		list add: (
			MethodReference new
				setStandardClass: mrClass
				methodSymbol: mrSel
		)
	].

	num _ CompiledMethod allInstances size.
	i _ 0.
	'processing...' displayProgressAt: Sensor cursorPoint from: 0 to: num during: [:bar |
		SystemNavigation new allBehaviorsDo: [ :class |
			class selectors do: [:s |
				bar value: (i _ i + 1).				
				(self string: (class sourceCodeAt: s) asString hasEncoding: encodingTag) ifTrue: [
					adder value: class value: s.
				]
			]
		]
	].

	^ list.
