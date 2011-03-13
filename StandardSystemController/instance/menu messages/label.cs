label
	| newLabel |
	FillInTheBlank
		request: 'Edit the label, then type RETURN.'
		displayAt: Sensor cursorPoint - (0@8)
		centered: true
		action: [:x | newLabel _ x]
		initialAnswer: view label.
	newLabel isEmpty ifFalse:
		[view relabel: newLabel]