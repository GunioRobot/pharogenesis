changeProgressValue: evt
	| answer |
	answer _ FillInTheBlank
		request: 'Enter new value (0 - 1.0)'
		initialAnswer: self value contents asString.
	answer isEmptyOrNil ifTrue: [^ self].
	self value contents: answer asNumber