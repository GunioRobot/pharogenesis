drawOn: aCanvas
	| xStart glyph |
	(font isNil or:[string isNil or:[string isEmpty]]) 
		ifTrue:[^aCanvas frameRectangle: bounds color: Color black].
	xStart _ 0.
	aCanvas asBalloonCanvas preserveStateDuring:[:balloonCanvas|
		balloonCanvas transformBy: self transform.
		balloonCanvas aaLevel: self smoothing.
		string do:[:char|
			glyph _ font at: char.
			balloonCanvas preserveStateDuring:[:subCanvas|
				subCanvas transformBy: (MatrixTransform2x3 withOffset: xStart@0).
				subCanvas 
					drawGeneralBezierShape: glyph contours
					color: color 
					borderWidth: borderWidth 
					borderColor: borderColor].
			xStart _ xStart + glyph advanceWidth.
		].
	].