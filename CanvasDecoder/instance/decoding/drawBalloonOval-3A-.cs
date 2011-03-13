drawBalloonOval: command

	| aRectangle aFillStyle borderWidth borderColor |

	aRectangle _ self class decodeRectangle: (command at: 2).
	aFillStyle _ self class decodeFillStyle: (command at: 3).
	borderWidth _ self class decodeInteger: (command at: 4).
	borderColor _ self class decodeColor: (command at: 5).

	self drawCommand: [ :c |
		c asBalloonCanvas 
			fillOval: aRectangle
			fillStyle: aFillStyle
			borderWidth: borderWidth
			borderColor: borderColor
	].