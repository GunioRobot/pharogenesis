changeColor
	"Change the color of the receiver -- triggered, e.g. from a menu"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #fillStyle:;
		originalColor: self color;
		putUpFor: self near: self fullBoundsInWorld