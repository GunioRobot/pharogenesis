changeParagraph: aParagraph 
	"Install aParagraph as the one to be edited by the receiver."

	UndoParagraph == paragraph ifTrue: [UndoParagraph := nil].
	paragraph := aParagraph.
	self resetState