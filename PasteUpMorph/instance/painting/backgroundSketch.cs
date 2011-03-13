backgroundSketch

	backgroundMorph ifNil: [^ nil].
	backgroundMorph owner ifNil:
		[backgroundMorph _ nil].	"has been deleted"
	^ backgroundMorph