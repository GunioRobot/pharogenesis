allExtantPlayers
	"Inefficient and ultimately unacceptable, but for the current round of demos it will help keep things from stalling just because they're on hidden book pages.  Produces a list of all Player objects associated with any Morph in the tree.  Call #flushPlayerListCache to force recomputation."

	playerList ifNotNil:
		[^ playerList].

	^ playerList _ (self allMorphsIncludingBookPages select: [:m | m costumee ~~ nil] thenCollect: [:m | m costumee]) asArray