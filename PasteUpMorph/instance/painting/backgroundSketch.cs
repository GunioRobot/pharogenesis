backgroundSketch

	backgroundMorph ifNil: [^ nil].
	backgroundMorph owner == self ifFalse:
		[backgroundMorph := nil].	"has been deleted"
	^ backgroundMorph