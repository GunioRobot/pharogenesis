addUserCustomEventNamed: aSymbol help: helpString
	self userCustomEventsRegistry at: aSymbol put: helpString.
