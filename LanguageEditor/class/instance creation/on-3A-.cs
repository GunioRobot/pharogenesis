on: aLanguage
	"answer an instance of the receiver on aLanguage"
	^ self new initializeOn: (NaturalLanguageTranslator localeID: aLanguage)