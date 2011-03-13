toDoMenu: aMenu

	date ifNil: [^ aMenu add: 'select a date' target: self selector: #yourself.].
	aMenu add: 'add new item' target: self selector: #addToDoItem.
	toDoListIndex > 0 ifTrue:
		[aMenu add: 'declare item done' target: self selector: #declareItemDone.
		aMenu add: 'remove item' target: self selector: #removeToDoItem].
	^ aMenu