saveProjectPreferences
	"Preserve the settings of all preferences presently held individually by projects in the receiver's projectPreferenceFlagDictionary"

	Preferences allPreferenceObjects do:
		[:aPreference | 
			aPreference localToProject ifTrue:
				[projectPreferenceFlagDictionary at: aPreference name put: aPreference preferenceValue]]