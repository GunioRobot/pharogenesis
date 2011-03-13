prepareToBeSaved
	"We are about to be written out. Release everything we don't want to carry around"
	myUndoStack reset.
	sharedMeshDict _ Dictionary new.
	sharedTextureDict _ Dictionary new.
