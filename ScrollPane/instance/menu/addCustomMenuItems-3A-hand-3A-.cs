addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	retractableScrollBar
		ifTrue: [aCustomMenu add: 'make scrollbar inboard' action: #retractableOrNot]
		ifFalse: [aCustomMenu add: 'make scrollbar retractable' action: #retractableOrNot].
	scrollBarOnLeft
		ifTrue: [aCustomMenu add: 'scroll bar on right' action: #leftOrRight]
		ifFalse: [aCustomMenu add: 'scroll bar on left' action: #leftOrRight]