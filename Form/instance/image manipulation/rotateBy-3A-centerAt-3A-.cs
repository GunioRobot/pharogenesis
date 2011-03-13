rotateBy: direction centerAt: aPoint
	"Return a copy of the receiver rotated either #right or #left"
	| newForm warp quad |
	newForm _ Form extent: height@width depth: depth.
	quad _ self boundingBox asQuad.
	quad _ (direction = #left ifTrue: [0 to: 3] ifFalse: [2 to: 5])
		collect: [:i | quad atWrap: i].
	(WarpBlt toForm: newForm)
		sourceForm: self;
		combinationRule: 3;
		copyQuad: quad toRect: newForm boundingBox.
	newForm offset: (self offset rotateBy: direction centerAt: aPoint).
	^ newForm
"
[Sensor anyButtonPressed] whileFalse:
	[((Form fromDisplay: (Sensor cursorPoint extent: 130@66))
		rotateBy: #left centerAt: 0@0) display]
"