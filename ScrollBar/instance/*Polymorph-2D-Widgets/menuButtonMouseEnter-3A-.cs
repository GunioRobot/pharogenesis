menuButtonMouseEnter: event
	"The mouse has entered the menu button."
	
	super menuButtonMouseEnter: event.
	Preferences gradientScrollbarLook ifFalse:[^self].
	menuButton
		fillStyle: self mouseOverButtonFillStyle;
		borderStyle: self mouseOverButtonBorderStyle;
		changed