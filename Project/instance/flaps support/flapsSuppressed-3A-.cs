flapsSuppressed: aBoolean
	"Make the setting of the flag that governs whether global flaps are suppressed in the project be as indicated and add or remove the actual flaps"

	self projectPreferenceFlagDictionary at: #showSharedFlaps put: aBoolean not.
	self == Project current  "Typical case"
		ifTrue:
			[Preferences setPreference: #showSharedFlaps toValue: aBoolean not]
		ifFalse:   "Anomalous case where this project is not the current one."
			[aBoolean
				ifTrue:		
					[Flaps globalFlapTabsIfAny do:
						[:aFlapTab | Flaps removeFlapTab: aFlapTab keepInList: true]]

				ifFalse:
					[Smalltalk isMorphic  ifTrue:
						[self currentWorld addGlobalFlaps]]].
	Project current assureNavigatorPresenceMatchesPreference