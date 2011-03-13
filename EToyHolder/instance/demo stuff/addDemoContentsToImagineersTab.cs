addDemoContentsToImagineersTab

	| book pic page s |
	book _ scaffoldingBook pageNamed: 'Imagis'.
	book ifNil: [book _ scaffoldingBook pageNamed: 'Painting'].
	book ifNotNil: [
		book removeEverything; addDressing.
		s _ self scaffoldingImagineersStrings first.
		book insertPageShowingString: s fontName: 'ComicPlain' fontSize: 16.
		book insertPage.
		pic _ SketchMorph new form: (ScriptingSystem formAtKey: 'CollagePic'); scalePoint: 0.7@0.7.
		page _ book currentPage.
		page extent: pic extent.
		book currentPage addMorph: (pic position: page topLeft).
		book firstPage].
