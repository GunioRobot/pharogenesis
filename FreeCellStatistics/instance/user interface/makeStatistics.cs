makeStatistics
	| row |

	row _ AlignmentMorph newRow.
	row
		wrapCentering: #center; cellPositioning: #leftCenter;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		color: self color;
		borderWidth: 2;
		borderColor: #inset;
		addMorphBack: (AlignmentMorph newColumn
			wrapCentering: #center; cellPositioning: #topCenter;
			color: self color;
			addMorph: (statsMorph _ TextMorph new contents: self statsText)).
	^row.