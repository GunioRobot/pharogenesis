determineCurrentLocale
	"For now just return the default locale.
	A smarter way would be to determine the current platforms default locale."

	^self localeID: LocaleID default