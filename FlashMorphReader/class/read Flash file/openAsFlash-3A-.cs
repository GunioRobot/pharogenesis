openAsFlash: fullFileName
	"Open a MoviePlayerMorph on the file (must be in .movie format)."
	| f player |
	f _ (FileStream readOnlyFileNamed: fullFileName) binary.
	player _ (FlashMorphReader on: f) processFile.
	player startPlaying.
	player open.
