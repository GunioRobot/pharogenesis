addCustomAction
	| string code |
	string := FillInTheBlank request:'Enter the Smalltalk code to execute:' initialAnswer:'Smalltalk beep.'.
	string isEmpty ifTrue:[^self].
	string := '[', string,']'.
	code := Compiler evaluate: string for: self notifying: nil logged: false.
	self removeActions.
	target := code.
	self on: #mouseDown send:(Message selector: #value).