decompress
	| newShape |
	(points isOctetString) ifTrue:[
		newShape := FlashCodec decompress: (ReadStream on: points).
		points := newShape points.
		leftFills := newShape leftFills.
		rightFills := newShape rightFills.
		lineWidths := newShape lineWidths.
		lineFills := newShape lineFills.
		fillStyles := newShape fillStyles].