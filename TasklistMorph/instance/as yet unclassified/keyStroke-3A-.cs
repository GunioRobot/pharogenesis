keyStroke: event 
	"Process keys to switch task."
	
	event commandKeyPressed ifFalse: [self done].
	event keyCharacter = Character arrowLeft
		ifTrue: [^self selectPreviousTask].
	event keyCharacter = Character arrowRight
		ifTrue: [^self selectNextTask]