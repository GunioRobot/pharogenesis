abandonLabelFocus
	| aLabel |
	"If the receiver's label has editing focus, abandon it"

	(aLabel _ self labelMorph) ifNotNil:
		[aLabel hasFocus ifTrue: [self currentHand newKeyboardFocus: nil]]