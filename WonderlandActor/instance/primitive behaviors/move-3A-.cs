move: aDirection
	"Move the actor one meter in the specified direction, taking 1 second and using the Gently animation style."

	^ (self move: aDirection distance: 1.0 duration: 1.0
			style: gently).

