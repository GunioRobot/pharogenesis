getRadialGradientFill
	"Geter for costume's useGradientFill"

	| aStyle |
	^ (aStyle _ costume renderedMorph fillStyle) isGradientFill and:
		[aStyle isRadialFill]