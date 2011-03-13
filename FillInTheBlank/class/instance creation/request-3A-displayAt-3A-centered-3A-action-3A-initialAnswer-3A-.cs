request: messageString displayAt: aPoint centered: centered action: aBlock initialAnswer: aString 
	"Answer an instance of me whose question is messageString. Once the user provides an answer, then evaluate aBlock. If centered, aBoolean, is false, display the view of the instance at aPoint; otherwise display it with its center at aPoint. "

	| newBlank fillInView savedArea |
	newBlank _ self new initialize.
	newBlank action: aBlock.
	newBlank contents: aString.
	fillInView _ FillInTheBlankView
				on: newBlank
				message: messageString
				displayAt: aPoint
				centered: centered.
	savedArea _ Form fromDisplay: fillInView displayBox.
	fillInView display.
	aString isEmpty
		ifFalse: [fillInView lastSubView controller selectFrom: 1 to: aString size].
	(fillInView lastSubView containsPoint: Sensor cursorPoint)
		ifFalse: [fillInView lastSubView controller centerCursorInView].
	fillInView controller startUp.
	fillInView release.
	savedArea displayOn: Display at: fillInView viewport topLeft