prologue: currentTime
	"This method does any work that needs to be done before the animation starts, including possibly adding the current state to the undo stack."

	"Undo stack stuff here"
	undoable ifTrue: [].

	startTime _ currentTime.
	endTime _ startTime + duration.
	state _ Running.
