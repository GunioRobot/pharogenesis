mouseLeave: event
	hasFocus _ false.
	retractableScrollBar ifTrue: [self hideScrollBars].
	(owner isSystemWindow) ifTrue: [owner paneTransition: event]
