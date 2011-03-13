toggleShowingTiles
	"Toggle whether tiles should be shown in the code pane"

	self okToChange ifTrue:
		[self showingTiles
			ifTrue:
				[contentsSymbol := #source.
				self setContentsToForceRefetch.
				self installTextualCodingPane.
				self contentsChanged]
			ifFalse:
				[contentsSymbol := #tiles.
				self installTilesForSelection.
				self changed: #tiles]]