isControlActive 
	view isNil ifTrue: [^ false].
	^ (view insetDisplayBox merge: scrollBar inside)
		containsPoint: sensor cursorPoint