menuButtonMouseLeave: event
	"The mouse has left the menu button."
	
	super menuButtonMouseLeave: event.
	Preferences gradientScrollbarLook ifFalse:[^self].
	menuButton
		fillStyle: self normalButtonFillStyle;
		borderStyle: self normalButtonBorderStyle;
		changed