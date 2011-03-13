insertPreferences
	ServicePreferences
		addPreference: self id
		categories: (Array with: self providerCategory)
		default: true
		balloonHelp: self description
		projectLocal: false
		changeInformee: self id -> #updateEnable
		changeSelector: #serviceUpdate
		viewRegistry: PreferenceViewRegistry ofBooleanPreferences