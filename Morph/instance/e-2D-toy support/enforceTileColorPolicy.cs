enforceTileColorPolicy
	Preferences coloredTilesEnabled
		ifTrue:
			[self makeAllTilesColored]
		ifFalse:
			[self makeAllTilesGreen]