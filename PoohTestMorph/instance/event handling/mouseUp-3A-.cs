mouseUp: evt
	lastPoint _ nil.
	self mouseMove: evt.
	points _ points contents asArray.
	self subdivide.
	self changed.
	"triangulation _ POTriangulation on: points."