answerForceSaveFile
	"Set the receiver to answer a forced new file stream."
	
	self actionSelector: #saveForcedSelectedFile.
	self changed: #okEnabled