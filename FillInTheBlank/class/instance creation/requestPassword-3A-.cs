requestPassword: queryString
	| model fillInView savedArea defaultAnswer |
	"Create an instance of me whose question is queryString. Invoke it centered at the cursor, and answer the string the user accepts. Answer the empty string if the user cancels."
	"FillInTheBlank requestPassword: 'POP password'"

	Smalltalk isMorphic
		ifTrue:
			[^ FillInTheBlankMorph requestPassword: queryString].

	defaultAnswer _ ''.
	model _ self new initialize.
	model contents: defaultAnswer.
	fillInView _
		FillInTheBlankView
			requestPassword: model
			message: queryString
			centerAt: Sensor cursorPoint
			answerHeight: 40.
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
