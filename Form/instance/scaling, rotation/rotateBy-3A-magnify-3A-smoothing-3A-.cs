rotateBy: deg magnify: scale smoothing: cellSize
	"Rotate the receiver by the indicated number of degrees and magnify. scale can be a Point to make for interesting 3D effects "
	"rot is the destination form, big enough for any angle."

	| side rot warp r1 pts p bigSide |
	side _ 1 + self extent r asInteger.
	bigSide _ (side asPoint * scale) rounded.
	rot _ self class extent: bigSide depth: self depth.
	warp _ (WarpBlt current toForm: rot)
		sourceForm: self;
		colorMap: (self colormapIfNeededFor: rot);
		cellSize: cellSize;  "installs a new colormap if cellSize > 1"
		combinationRule: Form paint.
	r1 _ (0@0 extent: side@side) align: (side@side)//2 with: self boundingBox center.

	"Rotate the corners of the source rectangle." 
	pts _ r1 innerCorners collect:
		[:pt | p _ pt - r1 center.
		(r1 center x asFloat + (p x asFloat*deg degreeCos) + (p y asFloat*deg degreeSin)) @
		(r1 center y asFloat - (p x asFloat*deg degreeSin) + (p y asFloat*deg degreeCos))].
	warp copyQuad: pts toRect: rot boundingBox.
	^ rot
"
 | a f |  f _ Form fromDisplay: (0@0 extent: 200@200).  a _ 0.
[Sensor anyButtonPressed] whileFalse:
	[((Form fromDisplay: (Sensor cursorPoint extent: 130@66))
		rotateBy: (a _ a+5) magnify: 0.75@2 smoothing: 2) display].
f display
"