performAction
	"Inform the model that this button has been pressed. Sent by the controller when this button is pressed."

	argumentsSelector
		ifNil:
			[actionSelector ifNotNil:
				[model perform: actionSelector]]
		ifNotNil:
			[model perform: actionSelector
				withArguments:
					(Array with: (argumentsProvider perform: argumentsSelector))]