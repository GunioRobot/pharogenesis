mouseDown: evt
	| localPt |
	localPt _ evt cursorPoint - self topLeft.
	self deleteAllBalloons.
	clickedTranslucency _ TransparentBox containsPoint: localPt.
	(DragBox containsPoint: localPt)
		ifTrue: [^ evt hand grabMorph: self].
	(RevertBox containsPoint: localPt)
		ifTrue: [^ self updateColor: originalColor feedbackColor: originalColor].
	self comeToFront.
	sourceHand _ evt hand.
	self startStepping.
