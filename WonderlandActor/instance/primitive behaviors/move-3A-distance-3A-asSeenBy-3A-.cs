move: aDirection distance: aDistance asSeenBy: reference
	"Move the actor the specified distance in the specified direction, taking 1 second and using the Gently animation style."

	^ (self move: aDirection distance: aDistance duration: 1.0 asSeenBy: reference
			style: gently).

