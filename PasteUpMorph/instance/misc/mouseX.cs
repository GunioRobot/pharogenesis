mouseX
	^ self isInWorld
		ifTrue:
			[(self cursorPoint x) - self left]
		ifFalse:
			[0]