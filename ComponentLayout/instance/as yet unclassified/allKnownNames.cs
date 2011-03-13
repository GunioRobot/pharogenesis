allKnownNames
	^ super allKnownNames, (self submorphs collect: [:m | m knownName] thenSelect: [:m | m ~~ nil])