doButtonAction: modifier 
	"Perform the action of this button. The first argument of the message sent to the target is the current state of this switch, 
	the second argument is the modifier button state."

	(target notNil and: [actionSelector notNil]) 
		ifTrue: 
			[^target perform: actionSelector
				withArguments: ((arguments copyWith: switchState) copyWith: modifier)]