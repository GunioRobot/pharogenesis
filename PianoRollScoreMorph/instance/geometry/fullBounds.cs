fullBounds
	"Overridden to clip submorph hit detection to my bounds."

	fullBounds ifNil: [fullBounds _ bounds].
	^ bounds
