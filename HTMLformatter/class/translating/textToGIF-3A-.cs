textToGIF: oneLineString
	| form filename |
	form _ (Form extent: 400@20 depth: Display depth) fillWhite.
	oneLineString displayOn: form at: 2@0. "form display."
	filename _ 'f',(SmallInteger maxVal atRandom) printString,'.gif'.
	GIFReadWriter putForm: form onFileNamed: filename.
	^(FileStream fileNamed: filename) contentsOfEntireFile

	