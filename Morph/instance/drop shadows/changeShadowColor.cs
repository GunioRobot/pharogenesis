changeShadowColor
	"Change the shadow color of the receiver -- triggered, e.g. from a menu"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #shadowColor:;
		originalColor: self shadowColor;
		putUpFor: self near: self fullBoundsInWorld