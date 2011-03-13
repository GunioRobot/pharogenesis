mouseDown: evt 
	self setProperty: #previousLiteral toValue: self literalFromContents.
	(upArrow notNil
			and: [(upArrow containsPoint: evt position)
					or: [downArrow containsPoint: evt position]])
		ifTrue: [self setProperty: #previousPoint toValue: evt position].
	self currentHand releaseKeyboardFocus.
	evt hand
		waitForClicksOrDrag: self
		event: evt
		selectors: {#mouseStillDown:. nil. nil. #startDrag:}
		threshold: 5.
	^ super mouseDown: evt