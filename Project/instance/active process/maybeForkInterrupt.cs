maybeForkInterrupt

	World ifNil: [ScheduledControllers cmdDotEnabled ifTrue:
					[[ScheduledControllers interruptName: 'User Interrupt'] fork]]
		ifNotNil: [self cmdDotEnabled ifTrue:
					[[self interruptName: 'User Interrupt'] fork]]