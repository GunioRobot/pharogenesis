method4

	x _ 0.
	y _ 0.
	[x < 100] whileTrue: [
		y _ y + x.
		x _ x + 1.
	].
	^y