justDroppedInto: aMorph event: anEvent
	isCollapsed
		ifTrue: [self position: ((self position max: 0@0) grid: 8@8).
				collapsedFrame _ self bounds]
		ifFalse: [fullFrame _ self bounds.
				TopWindow ~~ self ifTrue: [self activate]]