primitiveError: aString 
	"This method is called when the error handling results in a recursion in 
	calling on error: or halt or halt:."

	| context |
	(String
		streamContents: 
			[:s |
			s nextPutAll: '***System error handling failed***'.
			s cr; nextPutAll: aString.
			context _ thisContext sender sender.
			20 timesRepeat: [context == nil ifFalse: [s cr; print: (context _ context sender)]].
			s cr; nextPutAll: '-------------------------------'.
			s cr; nextPutAll: 'Type CR to enter an emergency evaluator.'.
			s cr; nextPutAll: 'Type any other character to restart.'])
		displayAt: 0 @ 0.
	[Sensor keyboardPressed] whileFalse.
	Sensor keyboard = Character cr ifTrue: [Transcripter emergencyEvaluator].
	Smalltalk isMorphic
		ifTrue: [World install "init hands and redisplay"]
		ifFalse: [ScheduledControllers searchForActiveController]