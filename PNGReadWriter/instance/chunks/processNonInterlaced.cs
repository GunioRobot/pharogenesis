processNonInterlaced
	| z filter |
	z _ ZLibReadStream on: chunk from: 1 to: chunk size.
	prevScanline _ ByteArray new: bytesPerScanline.
	0 to: height-1 do: [ :y |
		filter _ z next.
		(filter isNil or: [(filter between: 0 and: 4) not])
			ifTrue: [^ self].
		thisScanline _ z next: bytesPerScanline.
		self filterScanline: filter count: bytesPerScanline.
		self copyPixels: y.
		prevScanline replaceFrom: 1 to: bytesPerScanline with:
			thisScanline startingAt: 1
		]
