mouseEnter  "OBSOLETE"
	(retractableScrollBar and: [(submorphs includes: scrollBar) not])
		ifTrue: [self privateAddMorph: scrollBar atIndex: 1.
				self resizeScrollBar.
				scrollBar changed]