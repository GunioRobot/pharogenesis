rotateBy: direction centerAt: aPoint
	"Return a rotated copy of the receiver. 
	direction = #none, #right, #left, or #pi"
	| newForm quad rot |
	direction == #none ifTrue: [^ self].
	newForm _ self class extent: (direction = #pi ifTrue: [width@height]
											ifFalse: [height@width]) depth: depth.
	quad _ self boundingBox innerCorners.
	rot _ #(right pi left) indexOf: direction.
	(WarpBlt current toForm: newForm)
		sourceForm: self;
		colorMap: (self colormapIfNeededForDepth: depth);
		combinationRule: 3;
		copyQuad: ((1+rot to: 4+rot) collect: [:i | quad atWrap: i])
			 toRect: newForm boundingBox.
	newForm offset: (self offset rotateBy: direction centerAt: aPoint).
	^ newForm
"
[Sensor anyButtonPressed] whileFalse:
	[((Form fromDisplay: (Sensor cursorPoint extent: 130@66))
		rotateBy: #left centerAt: 0@0) display]
"
"Consistency test...
 | f f2 p | [Sensor anyButtonPressed] whileFalse:
	[f _ Form fromDisplay: ((p _ Sensor cursorPoint) extent: 31@41).
	Display fillBlack: (p extent: 31@41).
	f2 _ f rotateBy: #left centerAt: 0@0.
	(f2 rotateBy: #right centerAt: 0@0) displayAt: p]
"
