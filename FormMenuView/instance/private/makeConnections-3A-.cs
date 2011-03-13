makeConnections: indexInterval

	| connector buttonCache button aSwitchView |
	connector := Object new.  "a dummy model for connecting dependents."
	indexInterval do: [:index |
	buttonCache := (FormButtons at: index) shallowCopy.
	buttonCache form: (FormButtons at: index) form copy.
		buttonCache initialState = #true
			ifTrue: [button := OneOnSwitch newOn]
			ifFalse: [button := OneOnSwitch newOff].
		button onAction: [model changeTool: buttonCache value].
		button connection: connector.
		aSwitchView := self makeViews: buttonCache for: button.
		aSwitchView
			borderWidthLeft: 1 right: 0 top: 1 bottom: 1;
			action: #turnOn].
	aSwitchView borderWidth: 1.
