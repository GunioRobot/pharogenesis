checkCompressedFills: indexList
	"Check if the indexList (containing fill handles) is okay."
	| fillPtr length fillIndex |
	self inline: false.
	self var: #fillPtr declareC:'int *fillPtr'.
	"First check if the oops have the right format"
	(interpreterProxy isWords: indexList) ifFalse:[^false].

	"Then check the fill entries"
	length _ interpreterProxy slotSizeOf: indexList.
	fillPtr _ interpreterProxy firstIndexableField: indexList.
	1 to: length do:[:i|
		fillIndex _ fillPtr at: 0.
		"Make sure the fill is okay"
		(self isFillOkay: fillIndex) ifFalse:[^false].
		fillPtr _ fillPtr + 1].

	^true