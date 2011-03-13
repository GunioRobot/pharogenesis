columnWithHeader
	| col bh |
	col _ BorderedMorph new
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		clipSubmorphs: true;
		color: Color transparent;
		cellInset: 0;
		borderWidth: 0;
		layoutPolicy: ProportionalLayout new.
	
	bh _ self buttonHeight negated.
	col
		addMorph: self listMorph
		fullFrame: (LayoutFrame fractions: (0@0 corner: 1@1) offsets: (0@0 corner: 0@bh)).
	col
		addMorph: self filter buttonMorph
		fullFrame: (LayoutFrame fractions: (0@1 corner: 1@1) offsets: (0@bh corner: 0@0)).
		

	^ col