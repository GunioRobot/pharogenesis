abandonLabelFocus
	| aLabel |
	"If the receiver's label has editing focus, abandon it"
	(aLabel _ self labelMorph) ifNotNil:
		[aLabel hasFocus ifTrue:
			[aLabel contents: aLabel readFromTarget.
			aLabel handsWithMeForKeyboardFocus do:
				[:aHand | aHand newKeyboardFocus: nil]]]