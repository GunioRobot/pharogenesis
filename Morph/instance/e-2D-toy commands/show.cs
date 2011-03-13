show
	"Make sure this morph is on-stage."

	(self fullBounds intersects: self world bounds) ifFalse: [
		self position: self position - (1000000@100000).
		self wrap].  "be sure I'm on-stage"
