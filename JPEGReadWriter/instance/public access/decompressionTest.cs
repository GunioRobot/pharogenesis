decompressionTest
	"Test decompression; don't generate actual image"
	| xStep yStep x y |
	MessageTally spyOn: 
		[ ditherMask := DitherMasks at: 32.
		residuals := WordArray new: 3.
		sosSeen := false.
		self parseFirstMarker.
		[ sosSeen ] whileFalse: [ self parseNextMarker ].
		xStep := mcuWidth * DCTSize.
		yStep := mcuHeight * DCTSize.
		y := 0.
		1 
			to: mcuRowsInScan
			do: 
				[ :row | 
				x := 0.
				1 
					to: mcusPerRow
					do: 
						[ :col | 
						self decodeMCU.
						self idctMCU.
						self colorConvertMCU.
						x := x + xStep ].
				y := y + yStep ] ]