depth
	| depth |
	self subTriangles ifNil: [^ 0]
		ifNotNil: 
			[depth _ 0.
			self subTriangles do: [:subTriangle | depth _ depth max: subTriangle depth].
			^ depth + 1]