chooseInitialSettings
	"Set up the initial choices for Preferences.  2/7/96 sw
	 5/2/96 sw: added init for uniformWindowColors
	 5/22/96 sw: init reverseWindowStagger, clear out old window parms"

	"Preferences chooseInitialSettings"

	self setPreference: #uniformWindowColors toValue: false.
	self setPreference: #reverseWindowStagger toValue: false.
	self setPreference: #programmerMode toValue: false.
	
