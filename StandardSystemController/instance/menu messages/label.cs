label

	| newLabel |
	newLabel _ FillInTheBlank
		request: 'Edit the label, then type RETURN'
		initialAnswer: view label.
	newLabel isEmpty ifFalse: [view relabel: newLabel].
