initialize
	"self initialize"

	Preferences
		addPreference: #enableInternetConfig
		category: #general
		default: false
		balloonHelp: 'If true, set http proxy automatically on startUp. Only works on MacOS X for now'.

	Smalltalk addToStartUpList: self.
	Smalltalk addToShutDownList: self.