turnTo: aVector asSeenBy: reference
	"Turns the object to the specified orientation in its parent's coordinate system over one second using the Gently animation style."

	^ (self turnTo: aVector duration: 1.0 asSeenBy: reference
			style: gently).
