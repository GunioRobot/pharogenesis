changeColor

	ColorPickerMorph new
		sourceHand: self activeHand;
		target: self;
		selector: #color:;
		originalColor: self color;
		addToWorld: self world
			near: self fullBounds