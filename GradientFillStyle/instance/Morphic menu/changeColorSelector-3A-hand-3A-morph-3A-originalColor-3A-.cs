changeColorSelector: aSymbol hand: aHand morph: aMorph originalColor: originalColor

	ColorPickerMorph new
		sourceHand: aHand;
		target: self;
		selector: aSymbol;
		argument: aMorph;
		originalColor: originalColor;
		addToWorld: aMorph world
			near: aMorph fullBounds