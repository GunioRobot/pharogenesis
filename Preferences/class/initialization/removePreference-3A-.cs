removePreference: aSymbol
	"Remove all memory of the given preference symbol."
	
	self dictionaryOfPreferences removeKey: aSymbol ifAbsent: []