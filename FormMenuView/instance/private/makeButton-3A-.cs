makeButton: index

	| buttonCache button |
	buttonCache := (FormButtons at: index) shallowCopy.
	buttonCache form: (FormButtons at: index) form copy.
	button := Button newOff.
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
