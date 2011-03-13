openAsFlash: fullFileName
	"Open a MoviePlayerMorph on the file (must be in .movie format)."
	| f player |
	f := (FileStream readOnlyFileNamed: fullFileName) binary.
	player := (FlashMorphReader on: f) processFile.
	player startPlaying.
	player open.
