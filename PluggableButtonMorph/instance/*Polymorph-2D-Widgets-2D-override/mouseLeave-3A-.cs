mouseLeave: evt
	"Update the appearance."
	
	Preferences gradientButtonLook
		ifTrue: [self changed]
		ifFalse: ["0.09375 is exact in floating point so no cumulative rounding error will occur"
				self color: (self color adjustBrightness: 0.09375).
				self update: nil].
	super mouseLeave: evt