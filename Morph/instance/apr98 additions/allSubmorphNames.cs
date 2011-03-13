allSubmorphNames
	^ self submorphs select: [:m | m knownName ~~ nil] thenCollect: [:m | m externalName]