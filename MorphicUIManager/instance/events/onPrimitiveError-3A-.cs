onPrimitiveError: aString
																																																																 	| context |
																																																																	
	(String
		streamContents: 
			[:s |
			s nextPutAll: '***System error handling failed***'.
			s cr; nextPutAll: aString.
			context := thisContext sender sender.
			20 timesRepeat: [context == nil ifFalse: [s cr; print: (context := context sender)]].
			s cr; nextPutAll: '-------------------------------'.
			s cr; nextPutAll: 'Type CR to enter an emergency evaluator.'.
			s cr; nextPutAll: 'Type any other character to restart.'])
		displayAt: 0 @ 0.
	[Sensor keyboardPressed] whileFalse.
	Sensor keyboard = Character cr ifTrue: [Transcripter emergencyEvaluator].
	
	World install "init hands and redisplay"