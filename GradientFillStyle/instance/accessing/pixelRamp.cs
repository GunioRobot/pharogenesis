pixelRamp
	^pixelRamp ifNil:[pixelRamp _ self computePixelRampOfSize: 512].