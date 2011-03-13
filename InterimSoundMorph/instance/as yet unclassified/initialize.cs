initialize

	super initialize.
	borderWidth _ 1.
	color _ Color r: 0 g: 0.8 b: 0.6.
	self extent: 30@30.
	self addGraphic.
	sound _ PluckedSound pitch: 880.0 dur: 2.0 loudness: 0.5.
