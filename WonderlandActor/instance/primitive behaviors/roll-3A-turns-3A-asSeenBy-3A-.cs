roll: aDirection turns: numTurns asSeenBy: reference
	"Roll the actor the specified number of turns in the specified direction, taking 1 second and using the Gently animation style."

	^ (self roll: aDirection turns: numTurns duration: 1.0 asSeenBy: reference
			style: gently).

