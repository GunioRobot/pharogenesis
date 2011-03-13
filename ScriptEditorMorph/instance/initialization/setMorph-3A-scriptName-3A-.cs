setMorph: anActorMorph scriptName: aString
	"Create a script editor for editing a named script."

	self setMorph: anActorMorph.
	scriptName _ aString.
	self addMorphFront: self buttonRowForEditor.
	self updateStatus.
	firstTileRow _ 2
