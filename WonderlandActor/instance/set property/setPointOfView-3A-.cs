setPointOfView: aVector
	"Sets the object's position and orientation"

	^ self setPointOfView: aVector duration: 1.0 style: gently.
