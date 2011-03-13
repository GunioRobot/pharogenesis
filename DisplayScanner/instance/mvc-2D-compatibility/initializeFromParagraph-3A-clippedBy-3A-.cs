initializeFromParagraph: aParagraph clippedBy: clippingRectangle 
	super 
		initializeFromParagraph: aParagraph
		clippedBy: clippingRectangle.
	bitBlt := UIManager default grafPort toForm: aParagraph destinationForm.
	bitBlt
		sourceX: 0;
		width: 0.	"Init BitBlt so that the first call to a primitive will not fail"
	bitBlt combinationRule: (Display depth = 1 
			ifTrue: [ aParagraph rule ]
			ifFalse: [ Form paint ]).
	bitBlt colorMap: (Bitmap 
			with: 0
			with: (bitBlt destForm pixelValueFor: aParagraph foregroundColor)).	"Assumes 1-bit deep fonts"
	bitBlt clipRect: clippingRectangle