buildUpperControls
	| refreshButton filterButton stopButton runOneButton runButton row bWidth listsMorph |
	row _ BorderedMorph new
				hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 borderWidth: 1;
				 borderColor: Color black;
				 layoutPolicy: ProportionalLayout new.
	row
		color: (Display depth <= 8
				ifTrue: [Color transparent]
				ifFalse: [Color gray alpha: 0.2]);
		 clipSubmorphs: true;
		 cellInset: 3;
		 borderWidth: 0.
	refreshButton _ self buildRefreshButton.
	filterButton _ self buildFilterButton.
	stopButton _ self buildStopButton.
	runOneButton _ self buildRunOneButton.
	runButton _ self buildRunButton.
	listsMorph _ self buildTestsList.
	bWidth _ 90.
	row
		addMorph: refreshButton
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 0 @ 0.33)
				offsets: (4 @ 2 corner: bWidth - 4 @ -2)).
	row
		addMorph: filterButton
		fullFrame: (LayoutFrame
				fractions: (0 @ 0.33 corner: 0 @ 0.66)
				offsets: (4 @ 2 corner: bWidth - 4 @ -2)).
	row
		addMorph: stopButton
		fullFrame: (LayoutFrame
				fractions: (0 @ 0.66 corner: 0 @ 1)
				offsets: (4 @ 2 corner: bWidth - 4 @ -2)).
	row
		addMorph: listsMorph
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 1)
				offsets: (bWidth  @ 0 corner: bWidth negated @ 0)).
	row
		addMorph: runOneButton
		fullFrame: (LayoutFrame
				fractions: (1 @ 0 corner: 1 @ 0.5)
				offsets: (bWidth negated + 4 @ 2 corner: -4 @ -2)).
	row
		addMorph: runButton
		fullFrame: (LayoutFrame
				fractions: (1 @ 0.5 corner: 1 @ 1)
				offsets: (bWidth negated + 4 @ 2 corner: -4 @ -2)).
	Preferences alternativeWindowLook
		ifTrue: [row color: Color transparent.
			row
				submorphsDo: [:m | m borderWidth: 2;
						 borderColor: #raised]].
	^ row