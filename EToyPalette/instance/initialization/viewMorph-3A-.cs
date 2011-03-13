viewMorph: aMorph
	
	| aPlayer aPresenter |
	currentPalette ifNotNil: [currentPalette delete].  "was the Paint palette"
	currentPalette _ nil.
	aPlayer _ aMorph assuredCostumee.
	aPresenter _ self presenter.
	viewPalette _ aPresenter viewerCache at: aPlayer ifAbsent:
		[self world "temp" addMorph: (viewPalette _ self partsViewerClass newSticky).
		viewPalette setPlayer: aPlayer.
		aPresenter cacheViewer: viewPalette forPlayer: aPlayer.
		viewPalette delete.
		viewPalette].
	BookMorph classPool at: #PageFlipSoundOn put: true.		"In case an error turned 
		the sound off"
	self presenter coloredTilesEnabled ifFalse:
		[viewPalette makeAllTilesGreen].
	self showViewPalette.