alignWith: anObject
	"This method sets the orientation of this instance to be the same as that of the specified object."

	^ self turnTo: anObject duration: 1.0 style: gently.
