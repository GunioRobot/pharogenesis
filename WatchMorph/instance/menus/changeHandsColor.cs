changeHandsColor
	"Let the user change the color of the hands of the watch."

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #handsColor:;
		originalColor: self color;
		putUpFor: self near: self fullBounds