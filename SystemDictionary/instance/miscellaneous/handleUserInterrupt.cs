handleUserInterrupt
	Preferences cmdDotEnabled ifTrue:
		[Smalltalk isMorphic
			ifTrue: [[Project current interruptName: 'User Interrupt'] fork]
			ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]]