writeRecentToFile
	| numChars aDirectory aFileName |
	"Smalltalk writeRecentToFile"
	aDirectory _ FileDirectory default.
	aFileName _ Utilities keyLike: 'squeak-recent.01' withTrailing: '.log' satisfying:
		[:aKey | (aDirectory includesKey: aKey) not].
	numChars _ ChangeList getRecentLocatorWithPrompt: 'copy logged source as far back as...'.
	numChars ifNotNil:
		[Smalltalk writeRecentCharacters: numChars toFileNamed: aFileName]