drawLine: command 
	| verb pt1Enc pt2Enc widthEnc colorEnc pt1 pt2 width color |
	verb _ command first.
	pt1Enc _ command second.
	pt2Enc _ command third.
	widthEnc _ command fourth.
	colorEnc _ command fifth.
""
	pt1 _ self class decodePoint: pt1Enc.
	pt2 _ self class decodePoint: pt2Enc.
	width _ self class decodeInteger: widthEnc.
	color _ self class decodeColor: colorEnc.
""
	self
		drawCommand: [:c | c
				line: pt1
				to: pt2
				width: width
				color: color]