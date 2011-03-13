recover: nCharacters
	"Schedule an editable text view on the last n characters of changes."
	| changes |
	changes _ SourceFiles at: 2.
	changes setToEnd; skip: nCharacters negated.
	(FileStream newFileNamed: 'st80.recent') nextPutAll: (changes next: nCharacters); close; open; edit