chooseInsertionPointColor
	ColorPickerMorph new
		sourceHand: self currentHand;
		target: self;
		selector: #insertionPointColor:;
		originalColor: self insertionPointColor;
		addToWorld: self currentWorld
			near: self currentHand cursorBounds