openPreferencesInspector
	"Open a window on the current set of preferences choices, allowing the user to view and change their settings"
	
	Smalltalk hasMorphic
		ifFalse:	[self inspectPreferences]
		ifTrue:	[self openPreferencesControlPanel]