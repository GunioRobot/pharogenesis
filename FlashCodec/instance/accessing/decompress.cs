decompress
	| points leftFills rightFills lineWidths lineFills fillStyles |
	points _ self decompressPoints.
	leftFills _ self decompressRunArray.
	rightFills _ self decompressRunArray.
	lineWidths _ self decompressRunArray.
	lineFills _ self decompressRunArray.
	fillStyles _ self decompressFills.
	^FlashBoundaryShape points: points leftFills: leftFills rightFills: rightFills fillStyles: fillStyles lineWidths: lineWidths lineFills: lineFills