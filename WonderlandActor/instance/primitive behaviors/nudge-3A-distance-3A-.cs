nudge: aDirection distance: aDistance
	"Nudge the actor the specified object lengths in the specified direction, taking one second and using the Gently animation style."

	^ self nudge: aDirection distance: aDistance duration: 1.0 style: gently.
	

