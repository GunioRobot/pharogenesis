makeControlBar

	^AlignmentMorph newRow
		color: self colorNearBottom;
		borderColor: #inset;
		borderWidth: 2;
		inset: 0;
		hResizing: #spaceFill; vResizing: #shrinkWrap; centering: #center;
		yourself.