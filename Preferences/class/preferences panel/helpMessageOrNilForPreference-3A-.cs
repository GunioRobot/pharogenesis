helpMessageOrNilForPreference: aSymbol
	"If the HelpDictionary has a help message prepared for aSymbol, return it, else return nil"
	HelpDictionary ifNil: [self initializeHelpMessages].
	^ HelpDictionary at: aSymbol ifAbsent: [nil]