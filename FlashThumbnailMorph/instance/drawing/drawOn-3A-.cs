drawOn: aCanvas
	(player == nil or:[frameNumber == nil]) ifTrue:[^super drawOn: aCanvas].
false ifTrue:[super drawOn: aCanvas.
			^aCanvas text: frameNumber printString bounds: self innerBounds font: nil color: Color red].
	image ifNil:[
		Cursor wait showWhile:[
			image _ player imageFormOfSize: (self extent - (self borderWidth * 2))
					 forFrame: frameNumber.
			frameNumber printString displayOn: image]].
	aCanvas frameRectangle: self bounds width: self borderWidth color: self borderColor.
	aCanvas paintImage: image at: self topLeft + self borderWidth.
