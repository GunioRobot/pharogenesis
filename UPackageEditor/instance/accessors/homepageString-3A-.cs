homepageString: newHomePage
	newHomePage asString = ''
		ifTrue: [ package homepage: nil ]
		ifFalse: [ package homepage: (Url absoluteFromText: newHomePage asString) ].

	self changed: #homepageString