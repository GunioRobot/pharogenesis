veryDeepFixupWith: deepCopier

	super veryDeepFixupWith: deepCopier.
	parent _ deepCopier references at: parent ifAbsent: [parent].
	self updateIfNecessary