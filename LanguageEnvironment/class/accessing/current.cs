current
	"LanguageEnvironment current"
	^Current ifNil: [
		Current := Locale current languageEnvironment.
		Current beCurrentNaturalLanguage.
		^Current]