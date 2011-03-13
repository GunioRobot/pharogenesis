editDescription
	"Allow the user to see and edit the documentation for this object"

	| reply |
	reply _ FillInTheBlank
		multiLineRequest: 'Kindly edit the description'
		centerAt: Sensor cursorPoint
		initialAnswer: self documentation
		answerHeight: 200.
	reply ifNil: [^ self].  "User cancelled out of the dialog"
	reply isEmptyOrNil ifFalse: [self documentation: reply]