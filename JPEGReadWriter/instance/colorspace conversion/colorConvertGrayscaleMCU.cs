colorConvertGrayscaleMCU

	| ySampleStream y bits |
	ySampleStream _ currentComponents at: 1.
	ySampleStream resetSampleStream.
	bits _ mcuImageBuffer bits.
	1 to: bits size do:
		[:i |
		y _ (ySampleStream nextSample) + greenResidual.
		y > MaxSample ifTrue: [y _ MaxSample].
		greenResidual _ y bitAnd: ditherMask.
		y _ y bitAnd: MaxSample - ditherMask.
		y < 1 ifTrue: [y _ 1].
		bits at: i put: (y<<16) + (y<<8) + y].
	