hideScrollBar
	(submorphs includes: scrollBar) ifFalse: [^self].
	self privateRemoveMorph: scrollBar.
	scrollBar privateOwner: nil.
	retractableScrollBar ifFalse: [self resetExtent].