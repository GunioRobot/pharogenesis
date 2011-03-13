initialize
	"Inititalize the class.
	Register with the PreferenceViewRegistry for ui themes."
	
	PreferenceViewRegistry ofUIThemePreferences register: self.
	Preferences 
		addPreference: #uiTheme 
		categories: #(morphic windows)
		default: UIThemeStandardSqueak
		balloonHelp: 'The style of user interface to use.'
		projectLocal: false
		changeInformee: nil
		changeSelector: nil
		viewRegistry: PreferenceViewRegistry ofUIThemePreferences