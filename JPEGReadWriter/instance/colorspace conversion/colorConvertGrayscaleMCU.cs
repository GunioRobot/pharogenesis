colorConvertGrayscaleMCU

	| ySampleStream y bits |
	ySampleStream _ currentComponents at: 1.
	ySampleStream resetSampleStream.
	bits _ mcuImageBuffer bits.
	1 to: bits size do:
		[:i |
		y _ (ySampleStream nextSample) + (residuals at: 2).
		y > MaxSample ifTrue: [y _ MaxSample].
		residuals at: 2 put: (y bitAnd: ditherMask).
		y _ y bitAnd: MaxSample - ditherMask.
		y < 1 ifTrue: [y _ 1].
		bits at: i put: 16rFF000000 + (y<<16) + (y<<8) + y].
	