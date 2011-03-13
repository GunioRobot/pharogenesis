handleUserInterrupt
	Preferences cmdDotEnabled ifTrue:
		[Smalltalk isMorphic
			ifTrue: [[CurrentProjectRefactoring currentInterruptName: 'User Interrupt'] fork]
			ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]]