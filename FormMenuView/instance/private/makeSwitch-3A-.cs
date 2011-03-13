makeSwitch: index

	| buttonCache button |
	buttonCache := (FormButtons at: index) shallowCopy.
	buttonCache form: (FormButtons at: index) form copy.
	buttonCache initialState = #true
		ifTrue: [button := Switch newOn]
		ifFalse: [button := Switch newOff].
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
