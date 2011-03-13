makeSwitch: index

	| buttonCache button |
	buttonCache _ FormButtons at: index.
	buttonCache initialState = #true
		ifTrue: [button _ Switch newOn]
		ifFalse: [button _ Switch newOff].
	button onAction: [model changeTool: buttonCache value].
	self makeViews: buttonCache for: button.
