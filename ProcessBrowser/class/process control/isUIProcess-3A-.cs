isUIProcess: aProcess
	^aProcess == (Smalltalk isMorphic
		ifTrue: [ Project uiProcess ]
		ifFalse: [ ScheduledControllers activeControllerProcess ])