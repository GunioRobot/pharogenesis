nextPutImage: anImage

	| bits |
	anImage depth > 8 ifTrue: [
		self error: 'GIF does not support Forms deeper than 8-bits'].
	width _ anImage width.
	height _ anImage height.
	bitsPerPixel _ anImage depth.
	colorPalette _ Color indexedColors copyFrom: 1 to: (1 bitShift:
anImage depth).
		"Later use (anImage colorsUsed) and remap the pixels to be
in a compact color map"
	bits _ anImage bits.
	bitsPerPixel < 8 ifTrue:
		[bits _ self unpackBits: bits "BitMap, has words"
			depthTo8From: bitsPerPixel
			with: anImage width
			height: anImage height
			pad: 32].
	interlace _ false.
	self writeHeader.
	self writeBitData: bits.
	self close.
	^ anImage
