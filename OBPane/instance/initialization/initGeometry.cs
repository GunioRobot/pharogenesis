initGeometry
	self	
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		clipSubmorphs: true;
		color: Color transparent;
		cellInset: 0;
		borderWidth: 0;
		layoutPolicy: ProportionalLayout new.
		
	self addMorph: list.
	list bounds: self innerBounds.
		