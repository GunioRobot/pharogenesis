relabel
	| newLabel |
	newLabel _ FillInTheBlank 
		request: 'New title for this window'
		initialAnswer: labelString.
	newLabel isEmpty ifTrue: [^self].
	(model windowReqNewLabel: newLabel)
		ifTrue: [self setLabel: newLabel]