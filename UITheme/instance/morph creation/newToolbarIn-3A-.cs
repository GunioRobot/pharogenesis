newToolbarIn: aThemedMorph
	"Answer a new toolbar."

	|bar|
	bar := Morph new
		borderWidth: 0;
		color: Color transparent;
		changeTableLayout;
		layoutInset: (0@1 corner: 0@1);
		listDirection: #leftToRight;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
	bar
		addMorphBack: (self newToolSpacerIn: aThemedMorph);
		addMorphBack: (self newToolbarHandleIn: aThemedMorph);
		addMorphBack: (self newToolSpacerIn: aThemedMorph).
	^bar