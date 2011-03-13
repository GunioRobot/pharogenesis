hide
	"Move this morph way, way offstage!"

	self position < (5000@5000) ifTrue: [
		self position: self position + (1000000@100000)].
