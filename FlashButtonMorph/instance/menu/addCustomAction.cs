addCustomAction
	| string code |
	string _ FillInTheBlank request:'Enter the Smalltalk code to execute:' initialAnswer:'Smalltalk beep.'.
	string isEmpty ifTrue:[^self].
	string _ '[', string,']'.
	code _ Compiler evaluate: string for: self notifying: nil logged: false.
	self removeActions.
	target _ code.
	self on: #mouseDown send:(Message selector: #value).