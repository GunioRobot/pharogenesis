addSubTriangle: aTriangle
	self subTriangles ifNil: [
		self subTriangles: (OrderedCollection new: 3)].
	self subTriangles add: aTriangle