addTitle

	| string |
	string _ FillInTheBlank request: 'Title for this menu?'.
	string isEmpty ifTrue: [^ self].
	self addTitle: string.
