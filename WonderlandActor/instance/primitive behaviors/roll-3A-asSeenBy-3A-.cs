roll: aDirection asSeenBy: reference
	"Roll the actor 1/4 turn in the specified direction, taking 1 second and using the Gently animation style."

	^ (self roll: aDirection turns: 0.25 duration: 1.0 asSeenBy: reference
			style: gently).

