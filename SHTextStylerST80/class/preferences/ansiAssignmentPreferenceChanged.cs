ansiAssignmentPreferenceChanged
	"the user has changed the syntaxHighlightingAsYouTypeAnsiAssignment setting.
	If they have turned it on then force syntaxHighlightingAsYouTypeLeftArrowAssignment
	to be turned off"
	Preferences syntaxHighlightingAsYouTypeAnsiAssignment 
		ifTrue:[Preferences disable: #syntaxHighlightingAsYouTypeLeftArrowAssignment]