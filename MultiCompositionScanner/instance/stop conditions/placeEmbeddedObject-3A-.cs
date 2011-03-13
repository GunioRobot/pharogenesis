placeEmbeddedObject: anchoredMorph
	| descent |
	"Workaround: The following should really use #textAnchorType"
	anchoredMorph relativeTextAnchorPosition ifNotNil:[^true].
	(super placeEmbeddedObject: anchoredMorph) ifFalse: ["It doesn't fit"
		"But if it's the first character then leave it here"
		lastIndex < line first ifFalse:[
			line stop: lastIndex-1.
			^ false]].
	descent _ lineHeight - baseline.
	lineHeight _ lineHeight max: anchoredMorph height.
	baseline _ lineHeight - descent.
	line stop: lastIndex.
	presentationLine stop: lastIndex - numOfComposition.
	^ true