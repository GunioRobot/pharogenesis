initialize
	"Deprecation initialize"
	Preferences
		addBooleanPreference: #showDeprecationWarnings 
		category: #general "programming?" 
		default: true
		balloonHelp: 'If enabled, use of deprecated APIs is reported to the transcript.'.
	Preferences
		addBooleanPreference: #raiseDeprecatedWarnings 
		category: #general "programming?" 
		default: true
		balloonHelp: 'If enabled, use of a deprecated API raises a Deprecated warning.'.