findPreference: evt
	"Allow the user to submit a selector fragment; search for that among preference names; put up a list of qualifying preferences; if the user selects one of those, redirect the preferences panel to reveal the chosen preference"

	self findPreferencesMatching: (FillInTheBlank request: 'Search for preferences containing:' initialAnswer: 'color')