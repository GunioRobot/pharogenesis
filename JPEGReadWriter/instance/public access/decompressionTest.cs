decompressionTest
	"Test decompression; don't generate actual image"
	| xStep yStep x y |
MessageTally spyOn:[
	ditherMask _ DitherMasks at: 32.
	residuals _ WordArray new: 3.
	sosSeen _ false.
	self parseFirstMarker.
	[sosSeen] whileFalse: [self parseNextMarker].
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
			x _ x + xStep].
		y _ y + yStep].
].