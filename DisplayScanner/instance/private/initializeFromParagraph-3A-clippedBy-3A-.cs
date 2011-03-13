initializeFromParagraph: aParagraph clippedBy: clippingRectangle

	super initializeFromParagraph: aParagraph clippedBy: clippingRectangle.
	bitBlt _ BitBlt current toForm: aParagraph destinationForm.
	bitBlt combinationRule: Form paint.
	bitBlt colorMap:
		(Bitmap with: 0      "Assumes 1-bit deep fonts"
				with: (aParagraph foregroundColor pixelValueForDepth: bitBlt destForm depth)).
	bitBlt clipRect: clippingRectangle.
