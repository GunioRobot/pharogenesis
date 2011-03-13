primitiveError: aString 
	"This method is called when the error handling results in a recursion in calling
	on error: or halt or halt:."
	| context |
	(String streamContents:
		[:s |
		s nextPutAll: '**System error handling failed** '.
		s cr; nextPutAll: aString.
		context _ thisContext sender sender.
		20 timesRepeat: 
			[context == nil ifFalse: [s cr; print: (context _ context sender)]].
		s cr; nextPutAll: '**Type any character to restart.**'])
		displayAt: 0@0.
	[Sensor keyboardPressed] whileFalse.
	Sensor keyboard.
	ScheduledControllers searchForActiveController