openWorld

	| w |
	(w _ MVCWiWPasteUpMorph newWorldForProject: nil).
	w bounds: (0@0 extent: 400@300).
	self openOn: w
		label: 'A Morphic World'
		extent: w fullBounds extent + 2.
