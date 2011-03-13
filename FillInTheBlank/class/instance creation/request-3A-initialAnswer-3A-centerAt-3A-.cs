request: queryString initialAnswer: defaultAnswer centerAt: aPoint
	"Create an instance of me whose question is queryString with the given initial answer. Invoke it centered at the given point, and answer the string the user accepts. Answer the empty string if the user cancels."
	"FillInTheBlank
		request: 'Type something, then type CR.'
		initialAnswer: 'yo ho ho!'
		centerAt: Display center"

	| model fillInView savedArea |
	World ifNotNil: [
		^ FillInTheBlankMorph
			request: queryString
			initialAnswer: defaultAnswer
			centerAt: aPoint].

	model _ self new initialize.
	model contents: defaultAnswer.
	fillInView _
		(Smalltalk at: #FillInTheBlankView)
			on: model
			message: queryString
			centerAt: aPoint.
	savedArea _ Form fromDisplay: fillInView displayBox.
	fillInView display.
	defaultAnswer isEmpty
		ifFalse: [fillInView lastSubView controller selectFrom: 1 to: defaultAnswer size].
	(fillInView lastSubView containsPoint: Sensor cursorPoint)
		ifFalse: [fillInView lastSubView controller centerCursorInView].
	fillInView controller startUp.
	fillInView release.
	savedArea displayOn: Display at: fillInView viewport topLeft.
	^ model contents
