addPreference: prefSymbol categories: categoryList default: aValue balloonHelp: helpString projectLocal: localBoolean changeInformee: informeeSymbol  changeSelector: aChangeSelector viewRegistry: aViewRegistry
	"Add or replace a preference as indicated.  Reuses the preexisting Preference object for this symbol, if there is one, so that UI artifacts that interact with it will remain valid."

	| aPreference |
	aPreference := DictionaryOfPreferences at: prefSymbol ifAbsent: [Preference new].
	aPreference name: prefSymbol defaultValue: aValue helpString: helpString localToProject: localBoolean categoryList: categoryList changeInformee: informeeSymbol changeSelector:  aChangeSelector viewRegistry: aViewRegistry.
	DictionaryOfPreferences at: prefSymbol put: aPreference.
	self compileAccessMethodForPreference: aPreference