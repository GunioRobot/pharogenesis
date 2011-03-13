showWorldTaskbar: aBoolean 
	"Change the receiver to show the taskbar."
	
	self projectPreferenceFlagDictionary at: #showWorldTaskbar put: aBoolean.
	self == Project current ifTrue: [
		aBoolean == Preferences showWorldTaskbar
			ifFalse: [Preferences setPreference: #showWorldTaskbar toValue: aBoolean]].
	self assureTaskbarPresenceMatchesPreference