current
	"Answer the currently active Celeste (assuming that there's
	only one Celeste open at a given time) or open a new one."

	Celeste instanceCount = 0 ifTrue: [self open].
	^ Celeste someInstance