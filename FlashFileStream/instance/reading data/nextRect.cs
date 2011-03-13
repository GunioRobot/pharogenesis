nextRect
	"Read a (possibly compressed) rectangle"
	| nBits xMin xMax yMin yMax |
	self initBits.
	nBits := self nextBits: 5.
	xMin := self nextSignedBits: nBits.
	xMax := self nextSignedBits: nBits.
	yMin := self nextSignedBits: nBits.
	yMax := self nextSignedBits: nBits.
	^(xMin@yMin) corner: (xMax@yMax).