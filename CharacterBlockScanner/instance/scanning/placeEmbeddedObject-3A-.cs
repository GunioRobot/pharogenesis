placeEmbeddedObject: anchoredMorph
	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	specialWidth _ width.
	^ true