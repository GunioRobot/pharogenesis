handleUserInterrupt
	Preferences cmdDotEnabled
		ifTrue: [self isMorphic
				ifTrue: [[CurrentProjectRefactoring currentInterruptName: 'User Interrupt'] fork]
				ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]]