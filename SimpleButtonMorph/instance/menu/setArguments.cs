setArguments

	| s newArgs newArgsArray |
	s _ WriteStream on: ''.
	arguments do: [:arg | arg printOn: s. s nextPutAll: '. '].
	newArgs _ FillInTheBlank
		request:
'Please type the arguments to be sent to the target
when this button is pressed separated by periods' translated
		initialAnswer: s contents.
	newArgs isEmpty ifFalse: [
		newArgsArray _ Compiler evaluate: '{', newArgs, '}' for: self logged: false.
		self arguments: newArgsArray].
