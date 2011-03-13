performAction
	"Inform the model that this button has been pressed. Sent by the controller when this button is pressed."

	actionSelector ifNotNil: [model perform: actionSelector].
