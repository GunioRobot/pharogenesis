openAsMovie: fullFileName
	"Open a MoviePlayerMorph on the given file (must be in .movie format)."
 
	(self new openFileNamed: fullFileName) openInWorld