firstColor: aColor forMorph: aMorph hand: aHand
	colorRamp first value: aColor.
	pixelRamp _ nil.
	aMorph changed.