makeControls
	| row |

	row _ AlignmentMorph newRow.
	row
		centering: #center;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		color: self color;
		borderWidth: 2;
		borderColor: #inset;
		addMorphBack: self makeOkButton;
		addMorphBack: self makeResetButton.
	^row.