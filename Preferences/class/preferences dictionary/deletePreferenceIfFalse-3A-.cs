deletePreferenceIfFalse: aSymbol
	"If aSymbol is currently in the FlagDictionary and the corresponding value is currently false, then remove that element from the dictionary.  The result is that the preference will remain false when interrogated from the outside, but it will not show up in a Preferences control panel.  This keeps obscure preferences from distracting the user"

	| val |
	val _ FlagDictionary at: aSymbol ifAbsent: [^ self].
	val == false ifTrue: [self deletePreference: aSymbol]