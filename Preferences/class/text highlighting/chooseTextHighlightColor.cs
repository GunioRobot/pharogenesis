chooseTextHighlightColor
	ColorPickerMorph new
		sourceHand: self currentHand;
		target: self;
		selector: #textHighlightColor:;
		originalColor: self textHighlightColor;
		addToWorld: self currentWorld
			near: self currentHand cursorBounds