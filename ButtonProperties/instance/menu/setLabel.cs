setLabel

	| newLabel |
	newLabel _ FillInTheBlank
		request:
'Please a new label for this button'
		initialAnswer: self label.
	newLabel isEmpty ifFalse: [self label: newLabel].
