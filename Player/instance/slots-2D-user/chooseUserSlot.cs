chooseUserSlot
	| names aMenu result |
	(names _ self slotNames) size == 1
		ifTrue: [^ names first].
	aMenu _ SelectionMenu selections: names.
	result _ aMenu startUpWithCaption: 'Please choose a variable'.
	result isEmptyOrNil ifTrue: [^ nil].
	^ result