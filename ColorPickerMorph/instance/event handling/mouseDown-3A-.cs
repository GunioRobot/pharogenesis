mouseDown: evt
	| localPt |
	localPt _ evt cursorPoint - self topLeft.
	self deleteAllBalloons.
	clickedTranslucency _ TransparentBox containsPoint: localPt.
	self inhibitDragging ifFalse: [
		(DragBox containsPoint: localPt)
			ifTrue: [^ evt hand grabMorph: self].
	].
	(RevertBox containsPoint: localPt)
		ifTrue: [^ self updateColor: originalColor feedbackColor: originalColor].
	self inhibitDragging ifFalse: [self comeToFront].
	sourceHand _ evt hand.
	self startStepping.
