innerTriangles
	| out |
	out _ WriteStream on: (Array new: 100).
	self innerTriangleVerticesDo:[:p1 :p2 :p3| out nextPut: {p1. p2. p3}].
	^out contents