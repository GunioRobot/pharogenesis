scrollAbsolute: event
	"Just don't if it is not the red button and we are drawing gradients."
	
	Preferences gradientScrollbarLook ifFalse:[^super scrollAbsolute: event].
	event redButtonPressed ifFalse: [^self].
	^super scrollAbsolute: event