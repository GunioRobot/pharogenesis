doButtonAction
	"Perform the action of this button. The last argument of the message sent to the target is the new state of this switch."

	(target ~~ nil and: [actionSelector ~~ nil]) ifTrue: [
		target
			perform: actionSelector
			withArguments: (arguments copyWith: switchState)].
