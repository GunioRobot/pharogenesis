moveTo: aVector speed: aSpeed asSeenBy: reference
	"Moves the object to the specified position in its parent's coordinate system using the specified style over the specified duration."

	^ self moveTo: aVector duration: (((self distanceTo: aVector) / aSpeed) abs)
			asSeenBy: reference style: abruptly.
