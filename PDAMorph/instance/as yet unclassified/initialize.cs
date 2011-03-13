initialize

	super initialize.
	color _ Color lightGray.
	self extent: 406 @ 408.
	PDA new initialize openAsMorphIn: self.