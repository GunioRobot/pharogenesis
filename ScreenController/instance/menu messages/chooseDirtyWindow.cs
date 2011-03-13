chooseDirtyWindow
	"Put up a list of windows with unaccepted edits and let the user chose one to activate."
	"ScheduledControllers screenController chooseDirtyWindow"

	ScheduledControllers findWindowSatisfying:
		[:c | c model canDiscardEdits not].
