createPolygons
	| poly firstPoly |
	firstPoly _ nil.
	self innerTriangleEdgesDo:[:e1 :e2 :e3|
		poly _ PoohTriangle new.
		poly e1: e1 e2: e2 e3: e3.
		poly recomputeType.
		poly next: firstPoly.
		firstPoly _ poly.
	].
	^firstPoly