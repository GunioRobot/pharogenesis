setColor: aColor
	"Set the color of the graphic as requested"

	| aFillStyle aMorph |
	(aFillStyle _ (aMorph _ self costume renderedMorph) fillStyle) isGradientFill
		ifTrue:
			[aFillStyle firstColor: aColor forMorph: aMorph hand: nil]
		ifFalse:
			[aMorph color: aColor]