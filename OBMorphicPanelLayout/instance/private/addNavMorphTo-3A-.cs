addNavMorphTo: aMorph
	aMorph 
		addMorph: self navigationPanel buildScroller
		fullFrame: (LayoutFrame fractions: (0 @ 0 extent: 1 @ self columnProportion)).
