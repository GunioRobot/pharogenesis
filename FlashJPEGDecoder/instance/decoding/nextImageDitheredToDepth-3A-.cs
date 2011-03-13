nextImageDitheredToDepth: depth
	"Overwritten to yield every now and then."
	| form xStep yStep x y |
	ditherMask := DitherMasks
		at: depth
		ifAbsent: [self error: 'can only dither to display depths'].
	residuals := WordArray new: 3.
	sosSeen := false.
	self parseFirstMarker.
	[sosSeen] whileFalse: [self parseNextMarker].
	form := Form extent: (width @ height) depth: depth.
	xStep := mcuWidth * DCTSize.
	yStep := mcuHeight * DCTSize.
	y := 0.
	1 to: mcuRowsInScan do:
		[:row |
		"self isStreaming ifTrue:[Processor yield]."
		x := 0.
		1 to: mcusPerRow do:
			[:col |
			self decodeMCU.
			self idctMCU.
			self colorConvertMCU.
			mcuImageBuffer displayOn: form at: (x @ y).
			x := x + xStep].
		y := y + yStep].
	^ form