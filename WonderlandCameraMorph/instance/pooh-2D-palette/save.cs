save
	(self getWonderland getUndoStack) push: (UndoTextureChange for: currentActor from: backup).
	palette delete.
	mode _ nil
