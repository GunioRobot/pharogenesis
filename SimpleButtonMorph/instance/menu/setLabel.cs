setLabel

	| newLabel |
	newLabel _ FillInTheBlank
		request: 'Please enter a new label for this button'
		initialAnswer: self label.
	newLabel isEmpty ifFalse: [self labelString: newLabel].
