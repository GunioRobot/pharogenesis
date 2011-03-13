updateCurrentItem

	(peopleList includes: currentItem) ifTrue: [^ self].
	(scheduleList includes: currentItem) ifTrue: [^ self].
	(toDoList includes: currentItem) ifTrue: [^ self].
	(notesList includes: currentItem) ifTrue: [^ self].
	self currentItem: nil