drawRect: command 
	| verb rectEnc fillColorEnc borderWidthEnc borderColorEnc rect fillColor borderWidth borderColor |
	verb _ command first.
	rectEnc _ command second.
	fillColorEnc _ command third.
	borderWidthEnc _ command fourth.
	borderColorEnc _ command fifth.
	""
	rect _ self class decodeRectangle: rectEnc.
	fillColor _ self class decodeColor: fillColorEnc.
	borderWidth _ self class decodeInteger: borderWidthEnc.
	borderColor _ self class decodeColor: borderColorEnc.
	""
	self
		drawCommand: [:c | c
				frameAndFillRectangle: rect
				fillColor: fillColor
				borderWidth: borderWidth
				borderColor: borderColor]