restoreTextualCodingPane
	"If the receiver is showing tiles, restore the textual coding pane"

	self showingTiles ifTrue:
		[contentsSymbol := #source.
		self installTextualCodingPane]