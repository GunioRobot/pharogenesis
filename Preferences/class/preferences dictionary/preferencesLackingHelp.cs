preferencesLackingHelp
	^ self allPreferenceFlagKeys select:
		[:aKey | (self helpMessageOrNilForPreference: aKey) == nil]

"Preferences preferencesLackingHelp"