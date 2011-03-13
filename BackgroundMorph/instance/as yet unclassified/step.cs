step
	"Answer the desired time between steps in milliseconds."
	running ifTrue: [self slideBy: delta]