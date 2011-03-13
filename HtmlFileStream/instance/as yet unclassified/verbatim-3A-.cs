verbatim: aString
	"Do not attempt to translate the characters.  Use this to override translation in nextPutAll:.  User may write HTML directly to the file with this."

	^ super nextPutAll: aString
	"very tricky! depends on the fact that StandardFileStream nextPutAll: does not call nextPut, but does a direct write."