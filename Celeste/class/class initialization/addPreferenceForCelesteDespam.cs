addPreferenceForCelesteDespam.
	Preferences preferenceAt: #celesteDespam ifAbsent: [
		Preferences addPreference: #celesteDespam categories: #('general') default: false balloonHelp: 'enable de-spamming option in Celeste'.
	].