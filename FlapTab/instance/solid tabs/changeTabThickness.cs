changeTabThickness
	| newThickness |
	newThickness := FillInTheBlank request: 'New thickness:'
				initialAnswer: self tabThickness printString.
	newThickness notEmpty ifTrue: [self applyTabThickness: newThickness]