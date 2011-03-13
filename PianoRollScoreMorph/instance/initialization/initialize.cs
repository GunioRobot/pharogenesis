initialize

	super initialize.
	borderWidth _ 1.
	color _ Color white.
	self extent: 400@300.
	showMeasureLines _ true.
	showBeatLines _ false.
	self timeSignature: 4 over: 4.
	self clipSubmorphs: true.