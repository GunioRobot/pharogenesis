initializeFromParagraph: aParagraph clippedBy: clippingRectangle

	super initializeFromParagraph: aParagraph clippedBy: clippingRectangle.
	bitBlt _ BitBlt current toForm: aParagraph destinationForm.
	bitBlt fillColor: aParagraph fillColor.	"sets halftoneForm"
	bitBlt combinationRule: aParagraph rule.
	bitBlt clipRect: clippingRectangle.
