makeSwitch: index

	| buttonCache button |
	buttonCache _ (FormButtons at: index) shallowCopy.
	buttonCache form: (FormButtons at: index) form copy.
	buttonCache initialState = #true
		ifTrue: [button _ Switch newOn]
		ifFalse: [button _ Switch newOff].
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
