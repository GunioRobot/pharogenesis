turn: aDirection
	"Turn the actor once around in the specified direction, taking 1 second and using the Gently animation style."

	^ (self turn: aDirection turns: 0.25 duration: 1.0 style: gently).

