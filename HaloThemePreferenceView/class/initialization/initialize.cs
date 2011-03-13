initialize
	"adding the halo theme preference to Preferences and registering myself as its view"
	PreferenceViewRegistry ofHaloThemePreferences register: self.
	Preferences 
		addPreference: #haloTheme 
		categories: {#halos} 
		default: #iconicHaloSpecifications
		balloonHelp: ''
		projectLocal: false
		changeInformee: nil
		changeSelector: nil
		viewRegistry: PreferenceViewRegistry ofHaloThemePreferences.