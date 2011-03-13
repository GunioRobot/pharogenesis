placeEmbeddedObject: anchoredMorph
	"Workaround: The following should really use #textAnchorType"
	anchoredMorph relativeTextAnchorPosition ifNotNil:[^true].
	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	specialWidth _ anchoredMorph width.
	^ true