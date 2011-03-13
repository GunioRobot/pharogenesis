unload
	| pref |
	pref := Preferences preferenceAt: #browserShowsPackagePane.
	Preferences
		addPreference: #browserShowsPackagePane
		categories: pref categoryList
		default: pref defaultValue
		balloonHelp: pref helpString
		projectLocal: pref localToProject
		changeInformee: nil
		changeSelector: nil
		