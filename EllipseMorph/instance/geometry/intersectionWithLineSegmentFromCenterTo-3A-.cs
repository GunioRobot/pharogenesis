intersectionWithLineSegmentFromCenterTo: aPoint 
	| dx aSquared bSquared m mSquared xSquared x y dy |
	(self containsPoint: aPoint)
		ifTrue: [ ^aPoint ].
	dx _ aPoint x - self center x.
	dy _ aPoint y - self center y.
	dx = 0
		ifTrue: [ ^self bounds pointNearestTo: aPoint ].
	m _ dy / dx.
	mSquared _ m squared.
	aSquared _ (self bounds width / 2) squared.
	bSquared _ (self bounds height / 2) squared.
	xSquared _ 1 / ((1 / aSquared) + (mSquared / bSquared)).
	x _ xSquared sqrt.
	dx < 0 ifTrue: [ x _ x negated ].
	y _ m * x.
	^ self center + (x @ y) asIntegerPoint.
