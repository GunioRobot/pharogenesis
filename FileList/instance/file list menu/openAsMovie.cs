openAsMovie
	"Open a MoviePlayerMorph on the given file (must be in .movie format)."
 
	Smalltalk at: #Morph ifAbsent: [^ self beep].
	(MoviePlayerMorph new openFileNamed: self fullName) openInWorld