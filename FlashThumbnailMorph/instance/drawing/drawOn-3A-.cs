drawOn: aCanvas 
	(player isNil or: [frameNumber isNil]) ifTrue: [^super drawOn: aCanvas].
	false 
		ifTrue: 
			[super drawOn: aCanvas.
			^aCanvas 
				drawString: frameNumber printString
				in: self innerBounds
				font: nil
				color: Color red].
	image ifNil: 
			[Cursor wait showWhile: 
					[image := player imageFormOfSize: self extent - (self borderWidth * 2)
								forFrame: frameNumber.
					frameNumber printString displayOn: image]].
	aCanvas 
		frameRectangle: self bounds
		width: self borderWidth
		color: self borderColor.
	aCanvas paintImage: image at: self topLeft + self borderWidth