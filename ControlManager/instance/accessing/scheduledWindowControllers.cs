scheduledWindowControllers
	"Same as scheduled controllers, but without ScreenController.
	Avoids null views just after closing, eg, a debugger."

	^ scheduledControllers select:
		[:c | c ~~ screenController and: [c view ~~ nil]]