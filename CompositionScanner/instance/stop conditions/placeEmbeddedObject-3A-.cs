placeEmbeddedObject: anchoredMorph
	| descent |
	(super placeEmbeddedObject: anchoredMorph) ifFalse: [^ false].
	descent _ lineHeight - baseline.
	lineHeight _ lineHeight max: anchoredMorph height.
	baseline _ lineHeight - descent.
	^ true