displayView
	"This method is called by the system when the top view is framed or moved."

	model viewBox: self insetDisplayBox.
	self topView == ScheduledControllers scheduledControllers first view
		ifTrue: [model displayWorld]
		ifFalse: [model displayWorldAsTwoTone].  "just restoring the screen"
