turnTo: aVector speed: aSpeed asSeenBy: reference
	"Turns the object to the specified orientation in the reference's coordinate system at aSpeed turns per second."

	^ self turnTo: aVector duration: (((self angularDistanceTo: aVector) / (aSpeed * 360)) abs)
				asSeenBy: reference style: abruptly.

