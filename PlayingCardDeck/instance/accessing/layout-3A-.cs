layout: aSymbol
	" #grid #pile #stagger"
	layout _ aSymbol.
	layout == #grid 
		ifTrue:[self maxCellSize: SmallInteger maxVal].
	layout == #pile 
		ifTrue:[self maxCellSize: 0].
	layout == #stagger 
		ifTrue:[self maxCellSize: self staggerOffset].