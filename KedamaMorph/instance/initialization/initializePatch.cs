initializePatch

	| f |
	f _ self player addPatchVarNamed: #patch.
	patchesToDisplay _ Array new: 0.
	self addToPatchDisplayList: f.
	^ f.
