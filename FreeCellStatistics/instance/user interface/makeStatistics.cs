makeStatistics
	| row |

	row _ AlignmentMorph newRow.
	row
		centering: #center;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		color: self color;
		borderWidth: 2;
		borderColor: #inset;
		addMorphBack: (AlignmentMorph newColumn
			centering: #center;
			color: self color;
			addMorph: (statsMorph _ TextMorph new contents: self statsText)).
	^row.