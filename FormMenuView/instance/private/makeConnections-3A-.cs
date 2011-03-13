makeConnections: indexInterval

	| connector buttonCache button aSwitchView |
	connector _ Object new.  "a dummy model for connecting dependents."
	indexInterval do: [:index |
		buttonCache _ FormButtons at: index.
		buttonCache initialState = #true
			ifTrue: [button _ OneOnSwitch newOn]
			ifFalse: [button _ OneOnSwitch newOff].
		button onAction: [model changeTool: buttonCache value].
		button connection: connector.
		aSwitchView _ self makeViews: buttonCache for: button.
		aSwitchView
			borderWidthLeft: 1 right: 0 top: 1 bottom: 1;
			actionSelector: #turnOn].
	aSwitchView borderWidth: 1.
