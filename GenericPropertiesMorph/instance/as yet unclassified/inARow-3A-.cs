inARow: aCollectionOfMorphs

	| row |
	row _ AlignmentMorphBob1 newRow
		color: Color transparent;
		vResizing: #shrinkWrap;
		layoutInset: 1;
		wrapCentering: #center;
		cellPositioning: #leftCenter.
	aCollectionOfMorphs do: [ :each | row addMorphBack: each].
	^row
