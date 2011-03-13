magnify: aRectangle by: scale 
	"Answer a Form created as a scaling of the receiver.
	Scale may be a Float, and may be greater or less than 1.0."
	| newForm |
	newForm _ Form extent: (aRectangle extent * scale) truncated depth: depth.
	(WarpBlt toForm: newForm)
		sourceForm: self;
		combinationRule: 3;
		copyQuad: aRectangle asQuad toRect: newForm boundingBox.
	^ newForm

"Dynamic test...
[Sensor anyButtonPressed] whileFalse:
	[(Display magnify: (Sensor cursorPoint extent: 31@41) by: 5@3) display]
"
"Scaling test...
| f cp | f _ Form fromDisplay: (Rectangle originFromUser: 100@100).
Display restoreAfter: [Sensor waitNoButton.
[Sensor anyButtonPressed] whileFalse:
	[cp _ Sensor cursorPoint.
	(f magnify: f boundingBox by: (cp x asFloat@cp y asFloat)/f extent) display]]
"