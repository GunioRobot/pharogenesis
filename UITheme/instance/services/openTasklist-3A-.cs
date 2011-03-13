openTasklist: event
	"Open a tasklist to choose a window.
	Answer true if handled, false otherwise."

	Sensor commandKeyPressed ifFalse: [^false].
	 event keyCharacter = Character arrowLeft
		ifTrue: [TasklistMorph new openAsIs selectPreviousTask.
			^true].
	event keyCharacter = Character arrowRight
		ifTrue: [TasklistMorph new openAsIs selectNextTask.
			^true].
	^false