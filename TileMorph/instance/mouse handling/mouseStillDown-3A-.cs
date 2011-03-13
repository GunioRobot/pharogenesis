mouseStillDown: evt
	| aPoint label |
	"See if arrows are being pressed and call arrowAction:..."
	self flag: #arNote. "Fix 'significant' events below"
	upArrow ifNotNil:
		[aPoint _ evt cursorPoint.
		(label _ self labelMorph) ifNotNil:
			[label step. literal _ label valueFromContents].
		(upArrow containsPoint: aPoint) ifTrue:
			[self abandonLabelFocus.
			self variableDelay:
				[self arrowAction: 1].
			^ evt "hand noteSignificantEvent: evt"].
		(downArrow containsPoint: aPoint) ifTrue:
			[self abandonLabelFocus.
			self variableDelay:
				[self arrowAction: -1].
			^ evt "hand noteSignificantEvent: evt"]].

	super mouseStillDown: evt.
