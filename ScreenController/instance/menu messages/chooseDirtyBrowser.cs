chooseDirtyBrowser
	"Put up a list of browsers with unsubmitted changes in them, and activate the one selected by the user if any"
	"ScheduledControllers screenController chooseDirtyBrowser"
	ScheduledControllers findWindowSatisfying:
		[:contr |  (contr model isKindOf: Browser) and:
			[contr model hasUnacceptedInput]]