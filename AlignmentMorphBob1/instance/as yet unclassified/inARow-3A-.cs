inARow: aCollectionOfMorphs

	| row |
	row _ AlignmentMorph newRow
		color: Color transparent;
		vResizing: #shrinkWrap;
		layoutInset: 1;
		wrapCentering: #center;
		cellPositioning: #leftCenter.
	aCollectionOfMorphs do: [ :each | row addMorphBack: each].
	^row