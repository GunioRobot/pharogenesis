decompress
	| newShape |
	(points isOctetString) ifTrue:[
		newShape _ FlashCodec decompress: (ReadStream on: points).
		points _ newShape points.
		leftFills _ newShape leftFills.
		rightFills _ newShape rightFills.
		lineWidths _ newShape lineWidths.
		lineFills _ newShape lineFills.
		fillStyles _ newShape fillStyles].