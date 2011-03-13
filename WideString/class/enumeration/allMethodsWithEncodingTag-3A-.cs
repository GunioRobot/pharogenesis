allMethodsWithEncodingTag: encodingTag
	"Answer a SortedCollection of all the methods that implement the message 
	aSelector."

	| list adder num i |
	list := Set new.
	adder := [ :mrClass :mrSel |
		list add: (
			MethodReference new
				setStandardClass: mrClass
				methodSymbol: mrSel
		)
	].

	num := CompiledMethod allInstances size.
	i := 0.
	'processing...' displayProgressAt: Sensor cursorPoint from: 0 to: num during: [:bar |
		SystemNavigation new allBehaviorsDo: [ :class |
			class selectors do: [:s |
				bar value: (i := i + 1).				
				(self string: (class sourceCodeAt: s) asString hasEncoding: encodingTag) ifTrue: [
					adder value: class value: s.
				]
			]
		]
	].

	^ list.
