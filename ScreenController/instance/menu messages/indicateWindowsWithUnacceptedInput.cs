indicateWindowsWithUnacceptedInput
	"Put up a list of windows with unaccepted input, and let the user chose one to activate.  1/18/96 sw.  2/22/96 sw: use hasUnacceptedInput"

	ScheduledControllers findWindowSatisfying:
		[:contr |  contr model hasUnacceptedInput]