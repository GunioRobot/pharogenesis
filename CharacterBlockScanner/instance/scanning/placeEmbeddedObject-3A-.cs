placeEmbeddedObject: anchoredMorph
	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	specialWidth _ anchoredMorph width.
	^ true