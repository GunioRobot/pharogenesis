flipBy: direction centerAt: aPoint
	"Return a copy of the receiver flipped either #vertical or #horizontal."
	| newForm quad |
	newForm _ self class extent: self extent depth: depth.
	quad _ self boundingBox innerCorners.
	quad _ (direction = #vertical ifTrue: [#(2 1 4 3)] ifFalse: [#(4 3 2 1)])
		collect: [:i | quad at: i].
	(WarpBlt current toForm: newForm)
		sourceForm: self;
		colorMap: (self colormapIfNeededFor: newForm);
		combinationRule: 3;
		copyQuad: quad toRect: newForm boundingBox.
	newForm offset: (self offset flipBy: direction centerAt: aPoint).
	^ newForm
"
[Sensor anyButtonPressed] whileFalse:
	[((Form fromDisplay: (Sensor cursorPoint extent: 130@66))
			flipBy: #vertical centerAt: 0@0) display]
"
"Consistency test...
 | f f2 p | [Sensor anyButtonPressed] whileFalse:
	[f _ Form fromDisplay: ((p _ Sensor cursorPoint) extent: 31@41).
	Display fillBlack: (p extent: 31@41).
	f2 _ f flipBy: #vertical centerAt: 0@0.
	(f2 flipBy: #vertical centerAt: 0@0) displayAt: p]
"
