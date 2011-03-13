openInWorld
	"Add this morph to the world.  If in MVC, then provide a Morphic window for it."
	Smalltalk isMorphic ifFalse: [^ self openInMVC].
	World addMorph: self