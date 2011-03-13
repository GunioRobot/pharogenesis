insertPreferences
	super insertPreferences.
	ServicePreferences 
		addPreference: self childrenPreferences
		categories: { 
				('-- menu contents --' asSymbol).
				(self providerCategory)}
		default: ''
		balloonHelp: self description
		projectLocal: false
		changeInformee: self id -> #updateChildren
		changeSelector: #serviceUpdate
		viewRegistry: PreferenceViewRegistry ofTextPreferences