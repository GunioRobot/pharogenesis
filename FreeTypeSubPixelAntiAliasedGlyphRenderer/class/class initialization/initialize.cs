initialize
	"
	self initialize
	"
	FreeTypeGlyphRenderer current: self new.
	Preferences
		addBooleanPreference: #MonitorTypeLCD
		categories: {'FreeType'}
		default: true
		balloonHelp: 'Choose this if you are using an LCD monitor.'
		projectLocal: false
		changeInformee: FreeTypeSettings
		changeSelector: #MonitorTypeLCDPreferenceChanged.
	Preferences
		addBooleanPreference: #MonitorTypeCRT
		categories: {'FreeType'}
		default: false
		balloonHelp: 'Choose this if you are using a CRT monitor (i.e. not LCD)'
		projectLocal: false
		changeInformee: FreeTypeSettings
		changeSelector: #MonitorTypeCRTPreferenceChanged.
	FreeTypeSettings MonitorTypeLCDPreferenceChanged