generateInterpolatedForm
	"Draw the given form onto the canvas using the Balloon 3D engine"
	| aCanvas extent |
	extent _ (originalForm extent * scalePoint) asIntegerPoint.
	rotatedForm _ Form extent: extent asIntegerPoint depth: originalForm depth.
	aCanvas _ rotatedForm getCanvas.
	^self drawInterpolatedImage: originalForm on: aCanvas