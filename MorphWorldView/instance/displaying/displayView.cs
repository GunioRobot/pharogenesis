displayView
	"This method is called by the system when the top view is framed or moved."
	| topView |
	model viewBox: self insetDisplayBox.
	self updateSubWindowExtent.
	topView _ self topView.
	(topView == ScheduledControllers scheduledControllers first view
		or: [topView cacheBitsAsTwoTone not])
		ifTrue: [model displayWorldSafely]
		ifFalse: [model displayWorldAsTwoTone].  "just restoring the screen"