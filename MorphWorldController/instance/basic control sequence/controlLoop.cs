controlLoop 
	"Overridden to keep control active when the hand goes out of the view"

	| db |
	[self viewHasCursor  "working in the window"
		or: [Sensor noButtonPressed  "wandering with no button pressed"
		or: [model primaryHand submorphs size > 0  "dragging something outside"]]]
		whileTrue:   "... in other words anything but clicking outside"
			[self controlActivity.

			"Check for reframing since we hold control here"
			db _ view superView displayBox.
			view superView controller checkForReframe.
			db = view superView displayBox ifFalse:
				[self controlInitialize "reframe world if bounds changed"]].
