changeCenterColor
	"Let the user change the color of the center of the watch"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #centerColor:;
		originalColor: self color;
		putUpFor: self near: self fullBounds