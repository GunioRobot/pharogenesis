initializeProjectPreferences
	"Initialize the project's preferences from currently-prevailing preferences that are currently being held in projects in this system"
	
	projectPreferenceFlagDictionary _ Project current projectPreferenceFlagDictionary deepCopy.    "Project overrides in the new project start out being the same set of overrides in the calling project"

	Preferences allPreferenceObjects do:  "in case we missed some"
		[:aPreference |
			aPreference localToProject ifTrue:
				[(projectPreferenceFlagDictionary includesKey: aPreference name) ifFalse:
			[projectPreferenceFlagDictionary at: aPreference name put: aPreference preferenceValue]]].

	self isMorphic ifFalse: [self flapsSuppressed: true].
	(Project current projectParameterAt: #disabledGlobalFlapIDs  ifAbsent: [nil]) ifNotNilDo:
		[:idList | self projectParameterAt: #disabledGlobalFlapIDs put: idList copy]
