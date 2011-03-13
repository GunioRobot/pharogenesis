maybeForkInterrupt

	Preferences cmdDotEnabled ifFalse: [^self].
	[self interruptName: 'User Interrupt'] fork
