changeTabThickness
	| newThickness |
	newThickness := UIManager default request: 'New thickness:' translated initialAnswer: self tabThickness printString.
	newThickness isEmptyOrNil ifFalse: [self applyTabThickness: newThickness]