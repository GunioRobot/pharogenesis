mouseEnter: event
	hasFocus _ true.
	(owner isSystemWindow) ifTrue: [owner paneTransition: event].
	retractableScrollBar ifTrue:[ self hideOrShowScrollBars ].
