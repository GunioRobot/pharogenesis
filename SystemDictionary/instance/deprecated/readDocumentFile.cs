readDocumentFile
	"No longer used. Everything is now done in ProjectLauncher."
	
	self deprecated: 'Use SmalltalkImage current readDocumentFile'.
	StartupStamp _ '----STARTUP----', Time dateAndTimeNow printString, ' as ', SmalltalkImage current imageName.
