subdivide
	time _ [
		points _ self simplify: points.
		points _ self smoothen: points length: 10.
		points _ self regularize: points.
		self triangulate.
	] timeToRun.
	self changed.