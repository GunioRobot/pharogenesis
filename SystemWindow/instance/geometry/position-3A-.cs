position: newPos
	super position: newPos.
	isCollapsed
		ifTrue: [collapsedFrame _ self bounds]
		ifFalse: [fullFrame _ self bounds].
