makeButton: index

	| buttonCache button |
	buttonCache _ (FormButtons at: index) shallowCopy.
	buttonCache form: (FormButtons at: index) form copy.
	button _ Button newOff.
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
