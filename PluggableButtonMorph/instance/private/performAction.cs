performAction
	"Inform the model that this button has been pressed. Sent by the controller when this button is pressed."

	askBeforeChanging ifTrue: [model okToChange ifFalse: [^ self]].
	actionSelector ifNotNil: [model perform: actionSelector].
