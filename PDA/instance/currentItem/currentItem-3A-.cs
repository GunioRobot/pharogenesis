currentItem: newValue
	"Assign newValue to currentItem."

	currentItem class == newValue class ifFalse:
		["get rid of this hideous hack"
		(currentItem isMemberOf: PDAEvent) ifTrue: [self scheduleListIndex: 0].
		(currentItem isMemberOf: PDAToDoItem) ifTrue: [self toDoListIndex: 0].
		(currentItem isMemberOf: PDAPerson) ifTrue: [self peopleListIndex: 0].
		(currentItem isMemberOf: PDARecord) ifTrue: [self notesListIndex: 0]].
	currentItem _ newValue.
	self changed: #currentItemText