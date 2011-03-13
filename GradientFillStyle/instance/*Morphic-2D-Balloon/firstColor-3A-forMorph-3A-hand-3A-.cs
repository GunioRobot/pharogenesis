firstColor: aColor forMorph: aMorph hand: aHand
	colorRamp first value: aColor.
	isTranslucent _ nil.
	pixelRamp _ nil.
	aMorph changed.