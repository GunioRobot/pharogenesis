updateFeedbackForEvt: evt

	| newState |
	newState _ self containsPoint: evt cursorPoint.
	newState = showSelectionFeedback ifFalse: [
		borderColor isColor
			ifTrue:[showSelectionFeedback _ newState]
			ifFalse:[borderColor _ newState ifTrue:[#inset] ifFalse:[#raised]].
		self changed].
