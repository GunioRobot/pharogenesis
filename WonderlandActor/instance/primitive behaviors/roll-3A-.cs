roll: aDirection
	"Roll the actor a quarter turn in the specified direction, taking 1 second and using the Gently animation style."

	^ (self roll: aDirection turns: 0.25 duration: 1.0 style: gently).

