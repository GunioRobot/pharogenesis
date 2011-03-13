processNonInterlaced
	| z filter temp |
	z _ ZLibReadStream on: chunk from: 1 to: chunk size.
	prevScanline _ ByteArray new: bytesPerScanline.
	thisScanline := ByteArray new: bytesPerScanline.
	0 to: height-1 do: [ :y |
		filter _ (z next: 1) first.
		filtersSeen add: filter.
		(filter isNil or: [(filter between: 0 and: 4) not])
			ifTrue: [^ self].
		thisScanline _ z next: bytesPerScanline into: thisScanline startingAt: 1.
		self filterScanline: filter count: bytesPerScanline.
		self copyPixels: y.
		temp := prevScanline.
		prevScanline := thisScanline.
		thisScanline := temp.
		]
