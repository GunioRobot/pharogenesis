colorConvertIntYCbCrMCU

	| ySampleStream crSampleStream cbSampleStream y cb cr red green blue bits |
	ySampleStream _ currentComponents at: 1.
	cbSampleStream _ currentComponents at: 2.
	crSampleStream _ currentComponents at: 3.
	ySampleStream resetSampleStream.
	cbSampleStream resetSampleStream.
	crSampleStream resetSampleStream.
	bits _ mcuImageBuffer bits.
	1 to: bits size do:
		[:i |
		y _ ySampleStream nextSample.
		cb _ cbSampleStream nextSample - SampleOffset.
		cr _ crSampleStream nextSample - SampleOffset.
		red _ y + ((FIXn1n40200 * cr) // 65536) + redResidual.
		red > MaxSample
			ifTrue: [red _ MaxSample]
			ifFalse: [red < 0 ifTrue: [red _ 0]].
		redResidual _ red bitAnd: ditherMask.
		red _ red bitAnd: MaxSample - ditherMask.
		red < 1 ifTrue: [red _ 1].
		green _ y - ((FIXn0n34414 * cb) // 65536) -
			((FIXn0n71414 * cr) // 65536) + greenResidual.
		green > MaxSample
			ifTrue: [green _ MaxSample]
			ifFalse: [green < 0 ifTrue: [green _ 0]].
		greenResidual _ green bitAnd: ditherMask.
		green _ green bitAnd: MaxSample - ditherMask.
		green < 1 ifTrue: [green _ 1].
		blue _ y + ((FIXn1n77200 * cb) // 65536) + blueResidual.
		blue > MaxSample
			ifTrue: [blue _ MaxSample]
			ifFalse: [blue < 0 ifTrue: [blue _ 0]].
		blueResidual _ blue bitAnd: ditherMask.
		blue _ blue bitAnd: MaxSample - ditherMask.
		blue < 1 ifTrue: [blue _ 1].
		bits at: i put: (red bitShift: 16) + (green bitShift: 8) + blue].
	