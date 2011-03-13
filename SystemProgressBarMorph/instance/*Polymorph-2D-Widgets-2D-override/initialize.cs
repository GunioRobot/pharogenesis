initialize
	"Initialize the receiver from the current theme."
	
	super initialize.
	barSize := 0.
	self 
		fillStyle: (UITheme current progressBarFillStyleFor: self);
		borderStyle: (UITheme current progressBarBorderStyleFor: self);
		barFillStyle: (UITheme current progressBarProgressFillStyleFor: self)