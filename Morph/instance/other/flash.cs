flash

	| w |
	w _ self world.
	w ifNotNil: [
		Display flash: (bounds translateBy: w viewBox origin)].
