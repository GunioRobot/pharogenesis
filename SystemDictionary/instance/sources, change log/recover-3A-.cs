recover: nCharacters
	"Schedule an editable text view on the last n characters of changes."
	self writeRecentCharacters: nCharacters toFileNamed: 'st80.recent'