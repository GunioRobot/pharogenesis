nextImageDitheredToDepth: depth

	| form xStep yStep x y bb |
	ditherMask _ DitherMasks
		at: depth
		ifAbsent: [self error: 'can only dither to display depths'].
	residuals _ WordArray new: 3.
	sosSeen _ false.
	self parseFirstMarker.
	[sosSeen] whileFalse: [self parseNextMarker].
	form _ Form extent: (width @ height) depth: depth.
	bb _ BitBlt current toForm: form.
	bb sourceForm: mcuImageBuffer.
	bb colorMap: (mcuImageBuffer colormapIfNeededFor: form).
	bb sourceRect: mcuImageBuffer boundingBox.
	bb combinationRule: Form over.
	xStep _ mcuWidth * DCTSize.
	yStep _ mcuHeight * DCTSize.
	y _ 0.
	1 to: mcuRowsInScan do:
		[:row |
		x _ 0.
		1 to: mcusPerRow do:
			[:col |
			self decodeMCU.
			self idctMCU.
			self colorConvertMCU.
			bb destX: x; destY: y; copyBits.
			x _ x + xStep].
		y _ y + yStep].
	^ form