nudge: aDirection
	"Nudge the actor one length in the specified direction, taking 1 second and using the Gently animation style."

	^ (self nudge: aDirection distance: 1.0 duration: 1.0 style: gently).

