backgroundSketch

	backgroundMorph ifNil: [^ nil].
	backgroundMorph owner == self ifFalse:
		[backgroundMorph _ nil].	"has been deleted"
	^ backgroundMorph