setSecondColor: aColor
	"Setter for costume's second color, if it's using gradient fill; if not, does nothing"

	| aFillStyle aMorph |
	^ (aFillStyle _ (aMorph _ costume renderedMorph) fillStyle) isGradientFill
		ifTrue:
			[aFillStyle lastColor: aColor forMorph: aMorph hand: ActiveHand]