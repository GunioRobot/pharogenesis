mouseY
	^ self isInWorld
		ifTrue:
			[self bottom - (self cursorPoint y)]
		ifFalse:
			[0]