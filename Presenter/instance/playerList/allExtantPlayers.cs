allExtantPlayers
	"The initial intent here was to produce a list of Player objects associated with any Morph in the tree beneath the receiver's associatedMorph.  whether it is the submorph tree or perhaps off on unseen bookPages.  We have for the moment moved away from that initial intent, and in the current version we only deliver up players associated with the submorph tree only.

Call #flushPlayerListCache to force recomputation."

	playerList ifNotNil:
		[^ playerList].

	^ playerList _ (associatedMorph allMorphs select: 
		[:m | m player ~~ nil] thenCollect: [:m | m player]) asSet asArray