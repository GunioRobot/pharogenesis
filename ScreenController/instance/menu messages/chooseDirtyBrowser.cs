chooseDirtyBrowser
	"Put up a list of browsers with unsubmitted edits and activate the one selected by the user, if any."
	"ScheduledControllers screenController chooseDirtyBrowser"

	ScheduledControllers findWindowSatisfying:
		[:c | (c model isKindOf: Browser) and: [c model canDiscardEdits not]].
 