showScrollBar
	(submorphs includes: scrollBar) ifTrue: [^self].
	self resizeScrollBar.
	self privateAddMorph: scrollBar atIndex: 1.
	"scrollBar changed."
	retractableScrollBar ifFalse: [self resetExtent].