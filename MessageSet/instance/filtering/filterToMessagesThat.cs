filterToMessagesThat
	"Allow the user to type in a block which will be"

	| reply |
	reply _ FillInTheBlank
		multiLineRequest: 'Type your block here'
		centerAt: Sensor cursorPoint
		initialAnswer: '[:aClass :aSelector |
	
	]'
		answerHeight: 200.
	reply isEmptyOrNil ifTrue: [^ self].
	self filterFrom: (Compiler evaluate: reply)
