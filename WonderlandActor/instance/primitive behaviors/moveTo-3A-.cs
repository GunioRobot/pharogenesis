moveTo: aVector
	"Moves the object to the specified position in its parent's coordinate system over 1 second using the Gently animation style."

	^ (self moveTo: aVector duration: 1.0
			style: gently).
