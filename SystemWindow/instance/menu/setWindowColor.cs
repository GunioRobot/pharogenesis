setWindowColor
	"Allow the user to select a new basic color for the window"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #setWindowColor:;
		originalColor: self paneColorToUse;
		putUpFor: self
			near: self fullBounds