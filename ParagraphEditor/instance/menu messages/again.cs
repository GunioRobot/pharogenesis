again
	"Text substitution. If the left shift key is down, the substitution is made 
	throughout the entire Paragraph. Otherwise, only the next possible 
	substitution is made.
	Undoer & Redoer: #undoAgain:andReselect:typedKey:."

	"If last command was also 'again', use same keys as before"
	self againOrSame: (UndoMessage sends: #undoAgain:andReselect:typedKey:)