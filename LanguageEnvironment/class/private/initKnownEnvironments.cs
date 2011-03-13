initKnownEnvironments
	"LanguageEnvironment initKnownEnvironments"

	| env known id |
	known := Dictionary new.
	self allSubclassesDo: [:subClass | 
		subClass supportedLanguages do: [:language | 
			env := subClass new.
			id := LocaleID isoString: language.
			env localeID: id.
			known at: id put: env]].
	^known