setActionSelector

	| newSel |
	newSel _ FillInTheBlank
		request:
'Please type the selector to be sent to
the target when this button is pressed'
		initialAnswer: actionSelector.
	newSel isEmpty ifFalse: [self actionSelector: newSel].
