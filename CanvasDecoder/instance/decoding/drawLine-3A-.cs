drawLine: command
	| verb pt1Enc pt2Enc widthEnc colorEnc pt1 pt2 width color |
	verb := command at: 1.
	pt1Enc := command at: 2.
	pt2Enc := command at: 3.
	widthEnc := command at: 4.
	colorEnc := command at: 5.

	pt1 _ self class decodePoint: pt1Enc.
	pt2 _ self class decodePoint: pt2Enc.
	width _ self class decodeInteger: widthEnc.
	color _ self class decodeColor: colorEnc.

	self drawCommand: [ :c |
		c line: pt1 to: pt2 width: width color: color ]