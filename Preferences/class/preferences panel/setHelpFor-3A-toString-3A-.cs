setHelpFor: prefName toString: aString
	HelpDictionary ifNil: [self initializeHelpMessages].
	HelpDictionary at: prefName put: aString