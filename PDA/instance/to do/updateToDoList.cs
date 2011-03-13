updateToDoList

	date ifNil:
		[toDoList _ Array new. toDoListIndex _ 0.
		^ self changed: #toDoListItems].
	toDoList _ (allToDoItems select: [:c | c matchesKey: category andMatchesDate: date]) sort.
	toDoListIndex _ toDoList indexOf: currentItem.
	self changed: #toDoListItems