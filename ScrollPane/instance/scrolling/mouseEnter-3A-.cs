mouseEnter: event
	hasFocus _ true.
	(owner isKindOf: SystemWindow)
		ifTrue: [owner paneTransition: event].
	self hideOrShowScrollBar.
