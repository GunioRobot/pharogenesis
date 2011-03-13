setInitialContentForScaffoldingTabNamed: aName fromSelector: stringsSelector
	| aBook |
	(aBook _ scaffoldingBook  pageNamed: aName withBlanksTrimmed) ifNotNil:
		[aBook removeEverything; addDressing.
		(self perform: stringsSelector) do:
			[:str | aBook insertPageShowingString: str fontName: 'ComicPlain' fontSize:  16].
		aBook firstPage]