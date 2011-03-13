currentWorld
	"Answer a morphic world that is the current UI focus.
		If in an embedded world, it's that world.
		If in a morphic project, it's that project's world.  

	This method will never return nil, it will always return its best effort at returning a relevant world morph, but if need be -- if there are no worlds anywhere, it will create a new one."

	ActiveWorld ifNotNil:[^ActiveWorld].
	World ifNotNil:[^World].
	
	^ PasteUpMorph newWorldForProject: nil