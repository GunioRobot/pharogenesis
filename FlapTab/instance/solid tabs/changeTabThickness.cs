changeTabThickness
	| newThickness |
	newThickness _ FillInTheBlank request: 'New thickness:' initialAnswer: self tabThickness printString.
	newThickness size > 0 ifTrue:
		[self applyTabThickness: newThickness]