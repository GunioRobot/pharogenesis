maybeForkInterrupt
	Preferences cmdDotEnabled ifTrue:
		[Smalltalk isMorphic
			ifTrue: [[self interruptName: 'User Interrupt'] fork]
			ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]]