current
	"Answer the currently active Celeste (assuming that there's
	only one Celeste open at a given time) or open a new one."

	Smalltalk garbageCollect.
	^Celeste allSubInstances detect: [:e | e isActive] ifNone: [self open].
