setRadialGradientFill: aBoolean
	"Setter for costume's radialGradientFill"

	| aStyle |
	(aStyle _ costume renderedMorph fillStyle) isGradientFill
		ifTrue:
			[aStyle isRadialFill ~~ aBoolean ifTrue:
				[aStyle radial: aBoolean.
				costume renderedMorph changed]]