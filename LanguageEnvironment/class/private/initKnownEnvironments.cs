initKnownEnvironments
	"LanguageEnvironment initKnownEnvironments"

	| env known |
	known := Dictionary new.
	self allSubclassesDo: [:subClass | 
		subClass supportedLanguages do: [:language | 
			env := subClass new.
			env localeID: (LocaleID isoString: language).
			known at: env localeID put: env]].
	^known