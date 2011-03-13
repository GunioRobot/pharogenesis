updateFeedbackForEvt: evt

	| newState |
	newState _ self containsPoint: evt cursorPoint.
	newState = showSelectionFeedback ifFalse: [
		showSelectionFeedback _ newState.
		self changed].
