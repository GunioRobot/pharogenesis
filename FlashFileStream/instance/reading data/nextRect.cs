nextRect
	"Read a (possibly compressed) rectangle"
	| nBits xMin xMax yMin yMax |
	self initBits.
	nBits _ self nextBits: 5.
	xMin _ self nextSignedBits: nBits.
	xMax _ self nextSignedBits: nBits.
	yMin _ self nextSignedBits: nBits.
	yMax _ self nextSignedBits: nBits.
	^(xMin@yMin) corner: (xMax@yMax).