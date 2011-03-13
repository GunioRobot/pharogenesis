addNewRow

	| row |
	row _ AlignmentMorph newRow
		vResizing: #spaceFill;
		inset: 0;
		borderWidth: 0;
		extent: (bounds width)@(TileMorph defaultH);
		color: Color transparent.
	self addMorphBack: row.
	^ row
