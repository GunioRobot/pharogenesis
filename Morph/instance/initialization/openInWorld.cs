openInWorld
	"Add this morph to the world.  If in MVC, then provide a Morphic window for it."

	Smalltalk isMorphic
		ifTrue: [self openInWorld: self currentWorld]
		ifFalse: [self openInMVC]