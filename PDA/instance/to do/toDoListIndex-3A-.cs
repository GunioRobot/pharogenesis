toDoListIndex: newValue
	"Assign newValue to toDoListIndex."

	toDoListIndex = newValue ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	toDoListIndex _ newValue.
	self currentItem: (toDoListIndex ~= 0
						ifTrue: [toDoList at: toDoListIndex]
						ifFalse: [nil]).
	self changed: #toDoListIndex.