setActionSelector

	| oldSel newSel |
	setValueSelector == nil
		ifTrue: [oldSel _ '']
		ifFalse: [oldSel _ setValueSelector].
	newSel _ FillInTheBlank
		request:
'Please type the selector to be sent to
the target when this slider is changed'
		initialAnswer: oldSel.
	newSel isEmpty
		ifFalse: [self actionSelector: newSel].
