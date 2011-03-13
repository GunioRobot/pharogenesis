toggleListIndex: newListIndex

	(listIndex ~= 0 and: [listIndex ~= newListIndex]) ifTrue:
		[listSelections at: listIndex put: false].  "turn off old selection if was on"
	newListIndex = 0 
		ifTrue: [listIndex _ 0]
		ifFalse: [
			listSelections at: newListIndex  "Complement selection state"
					put: (listSelections at: newListIndex) not.
			listIndex _ (listSelections at: newListIndex)
				ifTrue: [newListIndex]  "and set selection index accordingly"
				ifFalse: [0]].
	self changed: #listIndex.
	self changed: #contents