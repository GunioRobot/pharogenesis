handleUserInterrupt
	Preferences cmdDotEnabled ifTrue:
		[Smalltalk isMorphic
			ifTrue: [[Project interruptName: 'User Interrupt'] fork]
			ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]]