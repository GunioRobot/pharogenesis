openAsFlash
	"Open a MoviePlayerMorph on the given file (must be in .movie format)."
	| f player |
	Smalltalk at: #Morph ifAbsent: [^ self beep].
	f _ (directory readOnlyFileNamed: self fullName) binary.
	player _ (FlashMorphReader on: f) processFile.
	player startPlaying.
	player open.