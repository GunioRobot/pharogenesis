drawOval: command
	| verb rectEnc colorEnc borderWidthEnc borderColorEnc rect color borderWidth borderColor |
	verb := command at: 1.
	rectEnc := command at: 2.
	colorEnc := command at: 3.
	borderWidthEnc := command at: 4.
	borderColorEnc := command at: 5.

	rect _ self class decodeRectangle: rectEnc.
	color _ self class decodeColor: colorEnc.
	borderWidth _ self class decodeInteger: borderWidthEnc.
	borderColor _ self class decodeColor: borderColorEnc.

	self drawCommand: [ :c |
		c fillOval: rect color: color borderWidth: borderWidth borderColor: borderColor ]
