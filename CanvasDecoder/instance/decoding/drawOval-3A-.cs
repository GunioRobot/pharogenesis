drawOval: command 
	| verb rectEnc colorEnc borderWidthEnc borderColorEnc rect color borderWidth borderColor |
	verb _ command first.
	rectEnc _ command second.
	colorEnc _ command third.
	borderWidthEnc _ command fourth.
	borderColorEnc _ command fifth.
	""
	rect _ self class decodeRectangle: rectEnc.
	color _ self class decodeColor: colorEnc.
	borderWidth _ self class decodeInteger: borderWidthEnc.
	borderColor _ self class decodeColor: borderColorEnc.
	""
	self
		drawCommand: [:c | c
				fillOval: rect
				color: color
				borderWidth: borderWidth
				borderColor: borderColor]