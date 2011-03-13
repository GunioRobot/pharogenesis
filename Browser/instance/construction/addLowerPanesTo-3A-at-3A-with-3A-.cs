addLowerPanesTo: window at: nominalFractions with: editString
	| commentPane |
	super addLowerPanesTo: window at: nominalFractions with: editString.
	commentPane := self buildMorphicCommentPane.
	window addMorph: commentPane fullFrame: (LayoutFrame fractions: (0@0.75 corner: 1@1)).
	self changed: #editSelection.