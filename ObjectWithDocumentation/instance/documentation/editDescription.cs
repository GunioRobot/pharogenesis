editDescription
	"Allow the user to see and edit the documentation for this object"
	| reply helpMessage |
	helpMessage := self documentation isNil
				ifTrue: [String new]
				ifFalse: [self documentation].
	reply := UIManager default
				multiLineRequest: 'Kindly edit the description' translated
				centerAt: Sensor cursorPoint
				initialAnswer: helpMessage
				answerHeight: 200.
	reply isEmptyOrNil
		ifFalse: [self documentation: reply]