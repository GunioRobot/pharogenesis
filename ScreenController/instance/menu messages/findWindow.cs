findWindow
	"Put up a menu of all windows on the screen, and let the user select one.
	 1/18/96 sw: the real work devolved to ControlManager>>findWindowSatisfying:"

	ScheduledControllers findWindowSatisfying: [:c | true]