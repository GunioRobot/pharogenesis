turn: aDirection turns: numTurns
	"Turn the actor the specified number of turns in the specified direction, taking one second and using the Gently animation style."

	^ (self turn: aDirection turns: numTurns duration: 1.0 style: gently).

