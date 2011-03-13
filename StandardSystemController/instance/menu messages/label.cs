label

	| newLabel |
	newLabel := UIManager default
		request: 'Edit the label, then type RETURN'
		initialAnswer: view label.
	newLabel isEmpty ifFalse: [view relabel: newLabel].
