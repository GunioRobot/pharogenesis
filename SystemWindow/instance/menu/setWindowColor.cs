setWindowColor
	ColorPickerMorph new
		sourceHand: self activeHand;
		target: self;
		selector: #setWindowColor:;
		originalColor: self paneColorToUse;
		addToWorld: self world
			near: self fullBounds