showWorldTaskbar
	"Answer whether the taskbar should exist in this project."
	
	^self projectPreferenceFlagDictionary
		at: #showWorldTaskbar
		ifAbsent: [Preferences showWorldTaskbar]