canAccept: aMorph
	"Answer whether this pad can accept the given morph"

	((aMorph isKindOf: PhraseTileMorph) or: [aMorph isKindOf: TileMorph orOf: WatcherWrapper]) 		ifTrue:
			[^ (aMorph resultType capitalized = self type capitalized "for bkwd compat") "or:
				[(aMorph resultType == #unknown) and: [type == #Player]]"].
	^ false