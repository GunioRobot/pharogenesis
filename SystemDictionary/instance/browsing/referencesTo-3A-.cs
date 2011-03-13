referencesTo: aSymbol
	"open a browser on all references in the system to the global symbol passed in.  SW 8/91"
	"Smalltalk referencesTo: #DebuggingFlags"
	self browseAllCallsOn: (self associationAt: aSymbol)