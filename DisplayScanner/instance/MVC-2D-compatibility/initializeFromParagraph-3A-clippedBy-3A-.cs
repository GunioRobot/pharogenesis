initializeFromParagraph: aParagraph clippedBy: clippingRectangle

	super initializeFromParagraph: aParagraph clippedBy: clippingRectangle.
	bitBlt _ BitBlt asGrafPort toForm: aParagraph destinationForm.
	bitBlt sourceX: 0; width: 0.	"Init BitBlt so that the first call to a primitive will not fail"
	bitBlt combinationRule:
		((Display depth = 1)
			ifTrue:
				[aParagraph rule]
			ifFalse:
				[Form paint]).
	bitBlt colorMap:
		(Bitmap with: 0      "Assumes 1-bit deep fonts"
				with: (bitBlt destForm pixelValueFor: aParagraph foregroundColor)).
	bitBlt clipRect: clippingRectangle