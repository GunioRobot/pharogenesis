maybeForkInterrupt

	Preferences cmdDotEnabled ifFalse: [^self].
	Smalltalk isMorphic
		ifTrue: [[self interruptName: 'User Interrupt'] fork]
		ifFalse: [[ScheduledControllers interruptName: 'User Interrupt'] fork]