setPointOfView: aVector asSeenBy: reference
	"Sets the object's position and orientation"

	^ self setPointOfView: aVector duration: 1.0 asSeenBy: reference style: gently.

