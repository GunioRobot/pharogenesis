toggleShowingTiles
	"Toggle whether tiles should be shown in the code pane"

	self okToChange ifTrue:
		[self showingTiles
			ifTrue:
				[contentsSymbol _ #source.
				self setContentsToForceRefetch.
				self installTextualCodingPane.
				self contentsChanged]
			ifFalse:
				[contentsSymbol _ #tiles.
				self installTilesForSelection.
				self changed: #tiles]]