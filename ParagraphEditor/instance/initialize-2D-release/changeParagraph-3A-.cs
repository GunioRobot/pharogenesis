changeParagraph: aParagraph 
	"Install aParagraph as the one to be edited by the receiver."

	UndoParagraph == paragraph ifTrue: [UndoParagraph _ nil].
	paragraph _ aParagraph.
	self resetState