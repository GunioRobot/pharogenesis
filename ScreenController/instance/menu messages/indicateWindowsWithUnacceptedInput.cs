indicateWindowsWithUnacceptedInput
	"Put up a list of windows with unaccepted input, and let the user chose one to activate"

	ScheduledControllers findWindowSatisfying:
		[:contr |  contr model hasUnacceptedInput]