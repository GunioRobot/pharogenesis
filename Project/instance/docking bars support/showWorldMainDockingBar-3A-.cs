showWorldMainDockingBar: aBoolean 
	"Change ther receiver to show the main docking bar"
	self projectPreferenceFlagDictionary at: #showWorldMainDockingBar put: aBoolean.
	""
	self == Project current
		ifTrue: [""
			aBoolean == Preferences showWorldMainDockingBar
				ifFalse: [Preferences setPreference: #showWorldMainDockingBar toValue: aBoolean]].
	""
	self assureMainDockingBarPresenceMatchesPreference