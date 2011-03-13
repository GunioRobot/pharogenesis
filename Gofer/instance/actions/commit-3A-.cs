commit: aString
	"Commit the specified packages with the given commit message aString."

	^ self execute: GoferCommit do: [ :operation | operation message: aString ]