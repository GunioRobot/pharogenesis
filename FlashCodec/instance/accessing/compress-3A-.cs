compress: aShape

	self compressPoints: aShape points.
	self compressRunArray: aShape leftFills.
	self compressRunArray: aShape rightFills.
	self compressRunArray: aShape lineWidths.
	self compressRunArray: aShape lineFills.
	self compressFills: aShape fillStyles.
	^stream contents