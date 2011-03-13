allKnownNames
	^ self allMorphs collect: [:m | m knownName] thenSelect: [:n | n ~~ nil]