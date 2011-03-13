setType: aSymbol

	type _ aSymbol.
	self color: (TilePadMorph colorForType: type).
	self extent: (TileMorph defaultW)@(TileMorph defaultH).
