makeRow

	^ LayoutMorph newRow
		color: color;
		inset: 0;
		centering: #center;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap
