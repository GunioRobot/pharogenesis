preferenceAt: aSymbol
	"Answer the Preference object at the given symbol, or nil if not there"

	^ DictionaryOfPreferences at: aSymbol ifAbsent: [nil]