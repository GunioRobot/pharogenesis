checkCompressedLineWidths: lineWidthList segments: nSegments
	"Check the run-length encoded lineWidthList matches nSegments"
	| length runLength nItems ptr |
	self inline: false.
	self var: #ptr declareC:'int *ptr'.
	length _ interpreterProxy slotSizeOf: lineWidthList.
	ptr _ interpreterProxy firstIndexableField: lineWidthList.
	nItems _ 0.
	0 to: length-1 do:[:i|
		runLength _ self shortRunLengthAt: i from: ptr.
		nItems _ nItems + runLength.
	].
	^nItems = nSegments