maybeForkInterrupt

	self cmdDotEnabled ifTrue:
		[[self interruptName: 'User Interrupt'] fork]