installProjectPreferences
	"Install the settings of all preferences presently held individually by projects in the receiver's projectPreferenceFlagDictionary"

	| localValue |
	Preferences allPreferenceObjects do:
		[:aPreference | 
			aPreference localToProject ifTrue:
				[localValue _ self projectPreferenceFlagDictionary at: aPreference name ifAbsent: [nil].
				localValue ifNotNil:
					[aPreference rawValue: localValue]]]