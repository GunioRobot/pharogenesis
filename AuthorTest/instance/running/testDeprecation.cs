testDeprecation
	| savedPref |
	savedPref := Preferences showDeprecationWarnings.
	Preferences setPreference: #showDeprecationWarnings toValue: true.
	
	self should: [ Utilities authorInitials ] raise: Warning.
	self should: [ Utilities authorInitialsPerSe ] raise: Warning.
	self should: [ Utilities setAuthorInitials ] raise: Warning.
	self should: [ Utilities setAuthorInitials: 'ak' ] raise: Warning.
	
	self should: [ Utilities authorName ] raise: Warning.
	self should: [ Utilities authorName: 'alan' ] raise: Warning.
	self should: [ Utilities authorNamePerSe ] raise: Warning.
	self should: [ Utilities setAuthorName ] raise: Warning.

	Preferences setPreference: #showDeprecationWarnings toValue: savedPref.
