openWorldWith: aMorph labelled: labelString

	| w |
	(w _ MVCWiWPasteUpMorph newWorldForProject: nil) addMorph: aMorph.
	w extent: aMorph fullBounds extent.
	w startSteppingSubmorphsOf: aMorph.
	self openOn: w
		label: labelString
		extent: w fullBounds extent + 2.
