mouseLeave: event
	hasFocus _ false.
	retractableScrollBar
		ifTrue: [self hideScrollBar].
	(owner isKindOf: SystemWindow)
		ifTrue: [owner paneTransition: event]