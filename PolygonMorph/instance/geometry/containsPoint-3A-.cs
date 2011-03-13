containsPoint: aPoint
	(super containsPoint: aPoint) ifFalse: [^ false].
	closed & color isTransparent not ifTrue:
		[self filledForm colors: (Array with: Color white with:
Color black).
		^ (filledForm pixelValueAt: aPoint - bounds
topLeft) = 1]
	ifFalse:
		[self lineSegmentsDo:
			[:p1 :p2 | (aPoint onLineFrom: p1 to: p2 within: (2 max: borderWidth+1//2) asFloat)
					ifTrue: [^ true]].
		arrowForms ifNotNil: [arrowForms do:
			[:f | (f pixelValueAt: aPoint - f offset) > 0
					ifTrue: [^ true]]].
		^ false]