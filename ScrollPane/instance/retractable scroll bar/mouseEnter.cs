mouseEnter
	(retractableScrollBar and: [(submorphs includes: scrollBar) not])
		ifTrue: [self resizeScrollBar.
				self privateAddMorph: scrollBar atIndex: 1]