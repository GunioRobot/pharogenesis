harmonizeTilesWithColorSetting
	self coloredTilesEnabled
		ifTrue:
			[self world makeAllTilesColored]
		ifFalse:
			[self world makeAllTilesGreen].

	self flushViewerCache