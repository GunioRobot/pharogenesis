preferenceAt: aSymbol ifAbsent: aBlock
	"Answer the Preference object at the given symbol, or the value of aBlock if not present"

	^ DictionaryOfPreferences at: aSymbol ifAbsent: [aBlock value]