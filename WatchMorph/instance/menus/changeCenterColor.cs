changeCenterColor

	ColorPickerMorph new
		sourceHand: self activeHand;
		target: self;
		selector: #centerColor:;
		originalColor: self color;
		addToWorld: self world
			near: self fullBounds