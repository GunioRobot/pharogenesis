drawRect: command
	| verb rectEnc fillColorEnc borderWidthEnc borderColorEnc rect fillColor borderWidth borderColor |
	verb := command at: 1.
	rectEnc := command at: 2.
	fillColorEnc := command at: 3.
	borderWidthEnc := command at: 4.
	borderColorEnc := command at: 5.

	rect _ self class decodeRectangle: rectEnc.
	fillColor _ self class decodeColor: fillColorEnc.
	borderWidth _ self class decodeInteger: borderWidthEnc.
	borderColor _ self class decodeColor: borderColorEnc.

	self drawCommand: [ :c |
		c frameAndFillRectangle: rect  fillColor: fillColor  borderWidth: borderWidth  borderColor: borderColor ]