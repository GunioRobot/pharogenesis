abandonLabelFocus
	| aLabel |
	"If the receiver's label has editing focus, abandon it"
	self flag: #arNote. "Probably unnecessary"
	(aLabel _ self labelMorph) ifNotNil:
		[aLabel hasFocus ifTrue:
			[aLabel contents: aLabel readFromTarget.
			aLabel handsWithMeForKeyboardFocus do:
				[:aHand | aHand releaseKeyboardFocus]]]