canAccept: aMorph

	((aMorph isKindOf: PhraseTileMorph) or:
	 [aMorph isKindOf: TileMorph]) ifTrue: [
		^ aMorph resultType == type].
	^ false
