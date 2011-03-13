mouseUpInSlider: event
	"The mouse button has been released."
	
	Preferences gradientScrollbarLook ifFalse:[^super mouseUpInSlider: event].
	sliderShadow hide.
	(slider containsPoint: event position)
		ifTrue: [slider
					fillStyle: self mouseOverThumbFillStyle;
					borderStyle: self mouseOverThumbBorderStyle]
		ifFalse: [self mouseLeaveThumb: event].
	slider changed