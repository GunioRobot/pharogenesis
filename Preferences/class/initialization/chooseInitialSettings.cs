chooseInitialSettings
	"Restore the default choices for Preferences."
	"Preferences chooseInitialSettings"

	self setPreference: #reverseWindowStagger toValue: true.
	self setPreference: #thoroughSenders toValue: true.
	self setPreference: #uniformWindowColors toValue: false.
	self setPreference: #warnIfNoChangesFile toValue: true.
	self setPreference: #warnIfNoSourcesFile toValue: true.
	self setPreference: #disableSounds toValue: false.
