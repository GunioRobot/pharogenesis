nextImageDitheredToDepth: depth
	"Overwritten to yield every now and then."
	| form xStep yStep x y |
	ditherMask _ DitherMasks
		at: depth
		ifAbsent: [self error: 'can only dither to display depths'].
	residuals _ WordArray new: 3.
	sosSeen _ false.
	self parseFirstMarker.
	[sosSeen] whileFalse: [self parseNextMarker].
	form _ Form extent: (width @ height) depth: depth.
	xStep _ mcuWidth * DCTSize.
	yStep _ mcuHeight * DCTSize.
	y _ 0.
	1 to: mcuRowsInScan do:
		[:row |
		"self isStreaming ifTrue:[Processor yield]."
		x _ 0.
		1 to: mcusPerRow do:
			[:col |
			self decodeMCU.
			self idctMCU.
			self colorConvertMCU.
			mcuImageBuffer displayOn: form at: (x @ y).
			x _ x + xStep].
		y _ y + yStep].
	^ form