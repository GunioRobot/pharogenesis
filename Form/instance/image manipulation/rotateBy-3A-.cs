rotateBy: deg
	"Rotate the receiver by the indicated number of degrees."
	"rot is the destination form, bit enough for any angle."
	| side rot warp r1 pts p p0 center |
	side _ 1 + ((width*width) + (height*height)) asFloat sqrt asInteger.
	rot _ Form extent: side@side depth: self depth.
	center _ rot extent // 2.

	"Now compute the sin and cos constants for the rotation angle." 
	warp _ (WarpBlt toForm: rot)
		sourceForm: self;
		combinationRule: Form over.
	r1 _ rot boundingBox align: center with: self boundingBox center.

	pts _ r1 asQuad collect:
		[:pt | p _ pt - r1 center.
		(r1 center x asFloat + (p x asFloat*deg degreeCos) + (p y asFloat*deg degreeSin)) @
		(r1 center y asFloat - (p x asFloat*deg degreeSin) + (p y asFloat*deg degreeCos))].
	warp copyQuad: pts toRect: rot boundingBox.
	^ rot
"
 | a f |  f _ Form fromDisplay: (0@0 extent: 200@200).  a _ 0.
[Sensor anyButtonPressed] whileFalse:
	[((Form fromDisplay: (Sensor cursorPoint extent: 130@66))
		rotateBy: (a _ a+5)) display].
f display
"