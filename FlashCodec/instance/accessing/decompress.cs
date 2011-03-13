decompress
	| points leftFills rightFills lineWidths lineFills fillStyles |
	points := self decompressPoints.
	leftFills := self decompressRunArray.
	rightFills := self decompressRunArray.
	lineWidths := self decompressRunArray.
	lineFills := self decompressRunArray.
	fillStyles := self decompressFills.
	^FlashBoundaryShape points: points leftFills: leftFills rightFills: rightFills fillStyles: fillStyles lineWidths: lineWidths lineFills: lineFills