request: queryString initialAnswer: defaultAnswer centerAt: aPoint
	"Create an instance of me whose question is queryString with the given initial answer. Invoke it centered at the given point, and answer the string the user accepts. Answer the empty string if the user cancels."
	"FillInTheBlankMorph
		request: 'Type something, then type CR.'
		initialAnswer: 'yo ho ho!'
		centerAt: Display center"

	| m |
	World ifNil: [^ ''].
	m _ self new
		setQuery: queryString
		initialAnswer: defaultAnswer
		answerHeight: 50.
	World addMorph: m centeredNear: aPoint.
	^ m getUserResponse
