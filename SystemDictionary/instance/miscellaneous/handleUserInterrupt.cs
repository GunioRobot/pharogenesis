handleUserInterrupt
	Preferences cmdDotEnabled ifTrue:
		[[Project interruptName: 'User Interrupt'] fork]