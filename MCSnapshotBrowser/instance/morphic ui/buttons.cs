buttons
	| row |
	row _ AlignmentMorph newRow.
	row
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		layoutInset: 0;
		addMorph: self classButton;
		addMorph: self separator;
		addMorph: self commentButton;
		addMorph: self separator;
		addMorph: self instanceButton.
	^ row