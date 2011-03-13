chooseUserSlot
	| names aMenu result |
	(names := self slotNames) size == 1
		ifTrue: [^ names first].
	aMenu := SelectionMenu selections: names.
	result := aMenu startUpWithCaption: 'Please choose a variable'.
	result isEmptyOrNil ifTrue: [^ nil].
	^ result