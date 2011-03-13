makeButton: index

	| buttonCache button |
	buttonCache _ FormButtons at: index.
	button _ Button newOff.
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
