lastColor: aColor forMorph: aMorph hand: aHand
	colorRamp last value: aColor.
	isTranslucent _ nil.
	pixelRamp _ nil.
	aMorph changed.