changeColorTarget: target forMorph: aMorph selector: aSymbol originalColor: aColor

	ColorPickerMorph new
		sourceHand: self;
		target: target;
		selector: aSymbol;
		originalColor: aColor;
		addToWorld: self world near: aMorph fullBounds