addToDoItem
	| newToDoItem |
	newToDoItem _ PDAToDoItem new key: self categorySelected; description: 'new item to do';
					dayPosted: Date today; priority: 1.
	allToDoItems _ allToDoItems copyWith: newToDoItem.
	self currentItem: newToDoItem.
	self updateToDoList