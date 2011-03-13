initialize
	"Initialize the receiver."

	super initialize.
	self diffMorph: self newDiffMorph.
	self changeTree: self newChangeTreeMorph.
	self
		changeProportionalLayout;
		addMorph: self changeTree
		fullFrame: (LayoutFrame fractions: (0@0 corner: 0.3@1));
		addMorph: self diffMorph
		fullFrame: (LayoutFrame fractions: (0.3@0 corner: 1@1)
					offsets: (ProportionalSplitterMorph splitterWidth @ 0 corner: 0@0));
		addPaneSplitters