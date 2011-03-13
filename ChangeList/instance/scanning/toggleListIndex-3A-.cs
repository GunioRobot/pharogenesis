toggleListIndex: newListIndex
	"2/1/96 sw: removed changed: call, to avoid extra refresh whenever selection changes. The call had been 'self changed: #contents', but everything appears to work fine with it omitted."

	(listIndex ~= 0 and: [listIndex ~= newListIndex]) ifTrue:
		[listSelections at: listIndex put: false].  "turn off old selection if was on"
	listSelections at: newListIndex  "Complement selection state"
			put: (listSelections at: newListIndex) not.
	listIndex _ (listSelections at: newListIndex)
		ifTrue: [newListIndex]  "and set selection index accordingly"
		ifFalse: [0].
	self changed: #listIndex