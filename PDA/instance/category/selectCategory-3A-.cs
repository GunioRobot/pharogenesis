selectCategory: cat

	category _ cat.
	self updateScheduleList.
	self updateToDoList.
	self updatePeopleList.
	self updateNotesList.
	currentItem ifNil: [^ self].
	(scheduleListIndex + toDoListIndex + peopleListIndex + notesListIndex) = 0 ifTrue:
		["Old current item is no longer current (not in any list)"
		currentItem _ nil.
		self changed: #currentItemText]