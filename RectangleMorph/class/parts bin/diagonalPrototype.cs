diagonalPrototype

	| rr |
	rr _ self authoringPrototype.
	rr useGradientFill; borderWidth: 0.
	rr fillStyle direction: rr extent.
	^ rr