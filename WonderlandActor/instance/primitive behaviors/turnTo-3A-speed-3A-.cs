turnTo: aVector speed: aSpeed 
	"Turns the object to the specified orientation in its parent's coordinate system at aSpeed turns per second."

	^ self turnTo: aVector duration: (((self angularDistanceTo: aVector) / (aSpeed * 360)) abs)
			style: abruptly.

