releaseCachedState
	super releaseCachedState.
	filledForm _ nil.
	arrowForms _ nil.
	borderForm _ nil.
	curveState _ nil.
	(self hasProperty: #flex) ifTrue:
		[self removeProperty: #unflexedVertices;
			removeProperty: #flex].
