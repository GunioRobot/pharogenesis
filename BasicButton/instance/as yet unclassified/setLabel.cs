setLabel
	| newLabel |
	newLabel _ FillInTheBlank
		request:
'Enter a new label for this button'
		initialAnswer: self label.
	newLabel isEmpty ifFalse: [self label: newLabel font: nil].
