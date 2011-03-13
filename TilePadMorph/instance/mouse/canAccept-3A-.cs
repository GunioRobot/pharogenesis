canAccept: aMorph
	"Answer whether this pad can accept the given morph"

	| itsType myType |
	((aMorph isKindOf: PhraseTileMorph) or: [aMorph isKindOf: TileMorph orOf: WatcherWrapper]) 		ifTrue:
			[^ ((itsType _ aMorph resultType capitalized) = (myType _ self type capitalized)) or:
				[(myType = #Graphic) and: [itsType = #Player]]].
	^ false