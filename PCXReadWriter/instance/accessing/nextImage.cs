nextImage
	"Read in the next PCX image from the stream."

	| bytes form |
	self readHeader.
	bytes _ self readBody.
	colorPalette _ self readPalette.
	self close.
	form _ ColorForm extent: width@height depth: bitsPerPixel.
	(Form new hackBits: bytes) displayOn: (Form new hackBits: form bits).
	form colors: colorPalette.
	^ form
