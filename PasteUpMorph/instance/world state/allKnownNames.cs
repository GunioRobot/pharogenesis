allKnownNames
	^ self allMorphsNotInPartsBins collect: [:m | m knownName] thenSelect: [:n | n ~~ nil]