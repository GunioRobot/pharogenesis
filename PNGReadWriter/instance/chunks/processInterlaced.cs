processInterlaced
	| z filter bytesPerPass startingCol colIncrement rowIncrement startingRow cx sc temp |
	startingCol _ #(0 4 0 2 0 1 0 ).
	colIncrement _ #(8 8 4 4 2 2 1 ).
	rowIncrement _ #(8 8 8 4 4 2 2 ).
	startingRow _ #(0 0 4 0 2 0 1 ).
	z _ ZLibReadStream on: chunk from: 1 to: chunk size.
	1 to: 7 do: [:pass |
		(self doPass: pass)
			ifTrue:
				[cx _ colIncrement at: pass.
				sc _ startingCol at: pass.
				bytesPerPass _ width - sc + cx - 1 // cx * bitsPerPixel + 7 // 8.
				prevScanline _ ByteArray new: bytesPerPass.
				thisScanline _ ByteArray new: bytesPerScanline.
				(startingRow at: pass)
					to: height - 1
					by: (rowIncrement at: pass)
					do: [:y |
						filter _ z next.
						filtersSeen add: filter.
						(filter isNil or: [(filter between: 0 and: 4) not])
							ifTrue: [^ self].
						thisScanline _ z next: bytesPerPass into: thisScanline startingAt: 1.
						self filterScanline: filter count: bytesPerPass.
						self copyPixels: y at: sc by: cx.
						temp := prevScanline.
						prevScanline := thisScanline.
						thisScanline := temp.
					]
				]
	].
	z atEnd ifFalse:[self error:'Unexpected data'].