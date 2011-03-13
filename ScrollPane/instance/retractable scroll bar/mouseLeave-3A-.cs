mouseLeave: event
	retractableScrollBar ifTrue: [self privateRemoveMorph: scrollBar]