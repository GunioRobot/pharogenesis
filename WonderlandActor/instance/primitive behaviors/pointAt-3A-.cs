pointAt: target
	"Turns the object to point at the specified target over the specified duration using the Gently animation style."

	^ (self pointAt: target duration: 1.0
			style: gently).
