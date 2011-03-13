removeToDoItem

	(self confirm: 'Rather than remove an item, it is
better to declare it done with a reason such as
''gave up'', or ''not worth it'', to keep the record.
Do you still wish to remove it?')
		ifFalse: [^ self].
	allToDoItems _ allToDoItems copyWithout: currentItem.
	self currentItem: nil.
	self updateToDoList.
