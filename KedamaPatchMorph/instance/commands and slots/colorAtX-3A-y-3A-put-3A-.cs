colorAtX: xPos y: yPos put: aColor

	| pixel |
	pixel _ aColor pixelValueForDepth: 32.
	self pixelAtX: xPos y: yPos put: pixel.
	self formChanged.
