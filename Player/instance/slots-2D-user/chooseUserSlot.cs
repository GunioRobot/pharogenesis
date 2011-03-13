chooseUserSlot
	| names aMenu result |
	(names _ self slotNames) size == 1
		ifTrue: [^ names first].
	aMenu _ SelectionMenu selections: names.
	result _ aMenu startUpWithCaption: 'Please choose a variable'.
	result size == 0 ifTrue: [^ nil].
	^ result