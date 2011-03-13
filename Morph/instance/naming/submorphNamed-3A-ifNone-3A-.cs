submorphNamed: aName ifNone: aBlock
	^ self submorphs detect: [:p | p knownName = aName] ifNone: [aBlock value]