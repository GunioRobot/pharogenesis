checkCompressedFillIndexList: fillList max: maxIndex segments: nSegs
	"Check the fill indexes in the run-length encoded fillList"
	| length runLength runValue nFills fillPtr |
	self inline: false.
	self var: #fillPtr declareC:'int *fillPtr'.
	length _ interpreterProxy slotSizeOf: fillList.
	fillPtr _ interpreterProxy firstIndexableField: fillList.
	nFills _ 0.
	0 to: length-1 do:[:i|
		runLength _ self shortRunLengthAt: i from: fillPtr.
		runValue _ self shortRunValueAt: 0 from: fillPtr.
		(runValue >= 0 and:[runValue <= maxIndex]) ifFalse:[^false].
		nFills _ nFills + runLength.
	].
	^nFills = nSegs