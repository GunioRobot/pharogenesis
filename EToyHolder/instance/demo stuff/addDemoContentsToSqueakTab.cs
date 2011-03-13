addDemoContentsToSqueakTab

	| book s |
	book _ scaffoldingBook pageNamed: 'Squeak'.
	book ifNil: [book _ scaffoldingBook pageNamed: 'Help'].
	book ifNotNil: [
		book removeEverything; addDressing.
		s _ self scaffoldingSqueakStrings first.
		book insertPageShowingString: s fontName: 'ComicPlain' fontSize: 16.
		book firstPage].
