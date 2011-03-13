drawInfiniteFill: command

	| aRectangle aFillStyle |

	aRectangle _ self class decodeRectangle: (command at: 2).
	aFillStyle _ InfiniteForm with: (self class decodeImage: (command at: 3)).

	self drawCommand: [ :c |
		c asBalloonCanvas 
			fillRectangle: aRectangle 
			fillStyle: aFillStyle.
	].