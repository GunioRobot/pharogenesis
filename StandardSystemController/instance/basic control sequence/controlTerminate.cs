controlTerminate
	status == #closed
		ifTrue: 
			[view ~~ nil ifTrue: [view release].
			ScheduledControllers unschedule: self.
			^self].
	view deEmphasize; cacheBits.
	view isCollapsed ifFalse: [model modelSleep].