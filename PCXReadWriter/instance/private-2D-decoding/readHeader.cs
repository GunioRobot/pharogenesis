readHeader

	| xMin xMax yMin yMax |
	self next.	"skip over manufacturer field"
	version _ self next.
	encoding _ self next.
	bitsPerPixel _ self next.
	xMin _ self nextWord.
	yMin _ self nextWord.
	xMax _ self nextWord.
	yMax _ self nextWord.
	width _ xMax - xMin + 1.
	height _ yMax - yMin + 1.
	self next: 4. "skip over device resolution"
	self next: 49. "skip over EGA color palette"
	colorPlanes _ self next.
	rowByteSize _ self nextWord.
	isGrayScale _ (self next: 2) = 2.
	self next: 58. "skip over filler"



