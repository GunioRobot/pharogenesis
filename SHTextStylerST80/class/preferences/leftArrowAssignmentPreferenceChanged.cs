leftArrowAssignmentPreferenceChanged
	"the user has changed the syntaxHighlightingAsYouTypeLeftArrowAssignment setting.
	If they have turned it on then force syntaxHighlightingAsYouTypeAnsiAssignment
	to be turned off"
	Preferences syntaxHighlightingAsYouTypeLeftArrowAssignment 
		ifTrue:[Preferences disable: #syntaxHighlightingAsYouTypeAnsiAssignment]