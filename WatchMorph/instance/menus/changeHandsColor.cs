changeHandsColor

	ColorPickerMorph new
		sourceHand: self activeHand;
		target: self;
		selector: #handsColor:;
		originalColor: self color;
		addToWorld: self world
			near: self fullBounds