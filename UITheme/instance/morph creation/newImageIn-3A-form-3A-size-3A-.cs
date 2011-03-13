newImageIn: aThemedMorph form: aForm size: aPoint
	"Answer a new image morph."

	^AlphaImageMorph new
		cornerStyle: aThemedMorph preferredCornerStyle;
		borderStyle: (BorderStyle inset width: 0);
		image: aForm size: aPoint