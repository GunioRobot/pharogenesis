editDescription
	"Allow the user to see and edit the documentation for this object"
	| reply helpMessage |
	helpMessage _ self documentation isNil
				ifTrue: [String new]
				ifFalse: [self documentation].
	reply _ FillInTheBlank
				multiLineRequest: 'Kindly edit the description' translated
				centerAt: Sensor cursorPoint
				initialAnswer: helpMessage
				answerHeight: 200.
	reply isEmptyOrNil
		ifFalse: [self documentation: reply]