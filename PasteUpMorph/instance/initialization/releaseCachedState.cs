releaseCachedState

	super releaseCachedState.
	turtleTrailsForm ifNotNil: [turtleTrailsForm hibernate].