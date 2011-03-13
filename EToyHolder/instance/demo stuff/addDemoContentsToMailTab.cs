addDemoContentsToMailTab

	| book pic page pt |
	book _ scaffoldingBook pageNamed: 'Mail'.
	book ifNotNil: [
		book insertPageShowingString: self cedarText fontName: 'ComicPlain' fontSize: 16.
		pic _ SketchMorph new form: (ScriptingSystem formAtKey: 'CedarPic').
		page _ book currentPage.
		pt _ (page left + (((page width - pic width) // 2) max: 0))@(page lastSubmorph bottom + 10).
		book currentPage addMorph: (pic position: pt).

		book insertPageShowingString: self kayaText fontName: 'ComicPlain' fontSize: 16.
		pic _ SketchMorph new form: (EToySystem formAtKey: 'KayaPic'); scalePoint: 0.5@0.5.
		page _ book currentPage.
		pt _ (page left + (((page width - pic width) // 2) max: 0))@(page lastSubmorph bottom + 10).
		book currentPage addMorph: (pic position: pt).
		book firstPage].
