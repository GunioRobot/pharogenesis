headerBitsForSampleCount: sampleCount stereoFlag: stereoFlag
	"Answer the number of extra header bits required for the given number of samples. This will be zero if I am not using frame headers."

	| frameCount bitsPerHeader |
	frameSizeMask = 0 ifTrue: [^ 0].
	frameCount _ (sampleCount / self samplesPerFrame) ceiling.
	bitsPerHeader _ 16 + 6.
	stereoFlag ifTrue: [bitsPerHeader _ 2 * bitsPerHeader].
	^ frameCount * bitsPerHeader
