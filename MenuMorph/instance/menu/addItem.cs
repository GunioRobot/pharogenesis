addItem

	| string sel |
	string _ FillInTheBlank request: 'Label for new item?'.
	string isEmpty ifTrue: [^ self].
	sel _ FillInTheBlank request: 'Selector?'.
	sel isEmpty ifFalse: [sel _ sel asSymbol].
	self add: string action: sel.
