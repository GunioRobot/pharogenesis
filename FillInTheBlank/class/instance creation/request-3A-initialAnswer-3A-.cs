request: queryString initialAnswer: defaultAnswer 
	"Create an instance of me whose question is queryString with the given initial answer. Invoke it centered at the given point, and answer the string the user accepts. Answer the empty string if the user cancels."
	"FillInTheBlank
		request: 'What is your favorite color?'
		initialAnswer: 'red, no blue. Ahhh!'"

	^ self request: queryString
		initialAnswer: defaultAnswer
		centerAt: Sensor cursorPoint.
