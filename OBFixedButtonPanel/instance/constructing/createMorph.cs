createMorph
	^(RectangleMorph new)
		layoutPolicy: TableLayout new;
		listDirection: #leftToRight;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		borderWidth: 0;
		wrapCentering: #center;
		cellPositioning: #leftCenter;
		rubberBandCells: true;
		layoutInset: 2;
		cellInset: 2;
		yourself