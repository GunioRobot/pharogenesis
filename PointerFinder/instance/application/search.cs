search
	Smalltalk garbageCollect.

	self initialize.
	
	Cursor wait showWhile: [
		[[toDo isEmpty or: [self followObject: toDo removeFirst]] whileFalse.
		toDo isEmpty and: [toDoNext isEmpty not]]
			whileTrue: 
				[toDo _ toDoNext.
				toDoNext _ OrderedCollection new: 5000]].

	self buildList