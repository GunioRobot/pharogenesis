xmagnify: aRectangle by: scale smoothing: cellSize
	"Answer a Form created as a scaling of the receiver.
	Scale may be a Float, and may be greater or less than 1.0."
	| newForm |
	newForm _ Form extent: (aRectangle extent * scale) truncated depth: depth.
	(WarpBlt toForm: newForm)
		sourceForm: self;
		colorMap: (self colormapIfNeededForDepth: depth);
		cellSize: cellSize;  "installs a new colormap if cellSize > 1"
		combinationRule: 3;
		clipRect: (Sensor cursorPoint extent: 20@20);
		copyQuad: aRectangle innerCorners toRect: newForm boundingBox.
	^ newForm

"Dynamic test...
[Sensor anyButtonPressed] whileFalse:
	[(Display xmagnify: Display boundingBox by: 0.1 smoothing: 1) display]
"
"Scaling test...
| f cp | f _ Form fromDisplay: (Rectangle originFromUser: 100@100).
Display restoreAfter: [Sensor waitNoButton.
[Sensor anyButtonPressed] whileFalse:
	[cp _ Sensor cursorPoint.
	(f magnify: f boundingBox by: (cp x asFloat@cp y asFloat)/f extent smoothing: 2) display]]
"