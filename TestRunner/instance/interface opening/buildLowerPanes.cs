buildLowerPanes
	| failuresList errorsList row tHeight divider |
	row _ AlignmentMorph newColumn hResizing: #spaceFill;
				 vResizing: #spaceFill;
				 layoutInset: 0;
				 borderWidth: 1;
				 borderColor: Color black;
				 layoutPolicy: ProportionalLayout new.
	self buildPassFailText.
	self buildDetailsText.
	self buildTestsList.
	failuresList _ self buildFailuresList.
	errorsList _ self buildErrorsList.
	tHeight _ 26.
	divider _ Array new: 3.
	1
		to: divider size
		do: [:index | 
			divider at: index put: BorderedSubpaneDividerMorph forBottomEdge.
			Preferences alternativeWindowLook
				ifTrue: [(divider at: index) extent: 4 @ 4;
						 color: Color transparent;
						 borderColor: #raised;
						 borderWidth: 2]].
	row
		addMorph: (passFailText borderWidth: 0)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ 0 corner: 0 @ tHeight - 1)).
	row
		addMorph: (divider at: 1)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ (tHeight - 1) corner: 0 @ tHeight)).
	row
		addMorph: (detailsText borderWidth: 0)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ tHeight corner: 0 @ (2 * tHeight - 1))).
	row
		addMorph: (divider at: 2)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ (2 * tHeight - 1) corner: 0 @ (2 * tHeight))).
	row
		addMorph: (failuresList borderWidth: 0)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0.6)
				offsets: (0 @ (2 * tHeight) corner: 0 @ -1)).
	row
		addMorph: (divider at: 3)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0.6 corner: 1 @ 0.6)
				offsets: (0 @ - 1 corner: 0 @ 0)).
	row
		addMorph: (errorsList borderWidth: 0)
		fullFrame: (LayoutFrame
				fractions: (0 @ 0.6 corner: 1 @ 1)
				offsets: (0 @ 0 corner: 0 @ 0)).
	^ row