multiLineRequest: queryString centerAt: aPoint initialAnswer: defaultAnswer answerHeight: answerHeight
	"Create a multi-line instance of me whose question is queryString with the given initial answer. Invoke it centered at the given point, and answer the string the user accepts. Answer the empty string if the user cancels."
	"FillInTheBlank
		multiLineRequest:
'Enter several lines; end input by accepting
or canceling or typing the enter key'
		centerAt: Display boundingBox center
		initialAnswer: 'bozo!'
		answerHeight: 100"

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
			multiLineOn: model
			message: queryString
			centerAt: aPoint
			answerHeight: answerHeight.
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
