showNote: aNote
	| fileName |
	fileName := (ServerAction serverDirectory) , 'ShowNote.html'.
	^HTMLformatter evalEmbedded: (FileStream fileNamed: fileName) contentsOfEntireFile with: aNote.
