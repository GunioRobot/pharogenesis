mouseMove: evt
	| aPoint label |
	"See if arrows are being pressed and call arrowAction:..."

	upArrow ifNotNil:
		[aPoint _ evt cursorPoint.
		(label _ self labelMorph) ifNotNil:
			[label step. literal _ label valueFromContents].
		(upArrow containsPoint: aPoint) ifTrue:
			[self abandonLabelFocus.
			self variableDelay:
				[self arrowAction: 1.
				self resizeToFitLabel].
			^ evt hand noteSignificantEvent: evt].
		(downArrow containsPoint: aPoint) ifTrue:
			[self abandonLabelFocus.
			self variableDelay:
				[self arrowAction: -1.
				self resizeToFitLabel].
			^ evt hand noteSignificantEvent: evt]].

	super mouseMove: evt.
