getSecondColor
	"Getter for costume's second color, if it's using gradient fill; sonst answers white."

	| aFillStyle |
	^ (aFillStyle _ costume renderedMorph fillStyle) isGradientFill
		ifTrue:
			[aFillStyle  colorRamp last value]
		ifFalse:
			[Color white]