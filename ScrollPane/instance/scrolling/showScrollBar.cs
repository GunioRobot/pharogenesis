showScrollBar
	(submorphs includes: scrollBar) ifTrue: [^self].
	self privateAddMorph: scrollBar atIndex: 1.
	self resizeScrollBar.
	scrollBar changed.
	retractableScrollBar ifFalse: [self resetExtent].