addLayoutMenuItems: topMenu hand: aHand
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addUpdating: #hasNoLayoutString action: #changeNoLayout.
	aMenu addUpdating: #hasProportionalLayoutString action: #changeProportionalLayout.
	aMenu addUpdating: #hasTableLayoutString action: #changeTableLayout.
	aMenu addLine.
	aMenu add: 'change layout inset...' translated action: #changeLayoutInset:.
	aMenu addLine.
	self addCellLayoutMenuItems: aMenu hand: aHand.
	self addTableLayoutMenuItems: aMenu hand: aHand.
	topMenu ifNotNil:[topMenu add: 'layout' translated subMenu: aMenu].
	^aMenu