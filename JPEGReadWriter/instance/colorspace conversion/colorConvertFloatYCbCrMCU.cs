colorConvertFloatYCbCrMCU

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
		cb _ cbSampleStream nextSample - FloatSampleOffset.
		cr _ crSampleStream nextSample - FloatSampleOffset.
		red _ self sampleFloatRangeLimit: (y + (1.40200 * cr)).
		green _ self sampleFloatRangeLimit: (y - (0.34414 * cb) - (0.71414 * cr)).
		blue _ self sampleFloatRangeLimit: (y + (1.77200 * cb)).
		bits at: i put: 16rFF000000 + (red << 16) + (green << 8) + blue].
	