initialize
	"Inititalize the class.
	Register with the PreferenceViewRegistry for ui sound themes."
	
	PreferenceViewRegistry ofSoundThemePreferences register: self.
	Preferences 
		addPreference: #soundTheme 
		categories: #(morphic windows)
		default: SoundTheme
		balloonHelp: 'The sound theme used for user interface events.'
		projectLocal: false
		changeInformee: nil
		changeSelector: nil
		viewRegistry: PreferenceViewRegistry ofSoundThemePreferences