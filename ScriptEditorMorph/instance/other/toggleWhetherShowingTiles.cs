toggleWhetherShowingTiles
	"Toggle between showing the method pane and showing the tiles pane"

	self showingMethodPane
		ifFalse:				"currently showing tiles"
			[self showSourceInScriptor]
		ifTrue:				"current showing textual source"
			[self savedTileVersionsCount >= 1
				ifTrue:
					[self revertToTileVersion]
				ifFalse:
					[self beep]]