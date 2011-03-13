scheduleListIndex: newValue
	"Assign newValue to scheduleListIndex."

	scheduleListIndex = newValue ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	scheduleListIndex _ newValue.
	self currentItem: (scheduleListIndex ~= 0
						ifTrue: [scheduleList at: scheduleListIndex]
						ifFalse: [nil]).
	self changed: #scheduleListIndex.