drawOn: aCanvas 
	"Display the receiver."
	| aaLevel |
	shape ifNil:[^aCanvas frameRectangle: self bounds color: Color black.].
	aCanvas asBalloonCanvas preserveStateDuring:[:balloonCanvas|
		balloonCanvas transformBy: self transform.
		aaLevel _ self defaultAALevel.
		aaLevel ifNotNil:[balloonCanvas aaLevel: aaLevel].
		balloonCanvas drawCompressedShape: shape.
	].