changeColorSelector: aSymbol hand: aHand morph: aMorph originalColor: originalColor
	"Change either the firstColor or the lastColor (depending on aSymbol).  Put up a color picker to hande it.  We always use a modal picker so that the user can adjust both colors concurrently."

	ColorPickerMorph new
		initializeModal: false;
		sourceHand: aHand;
		target: self;
		selector: aSymbol;
		argument: aMorph;
		originalColor: originalColor;
		putUpFor: aMorph near: aMorph fullBoundsInWorld