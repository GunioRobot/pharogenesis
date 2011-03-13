openWorldWith: aMorph labelled: labelString
	| w |
	self openOn: (w _ WorldMorph new addMorph: aMorph)
		label: labelString
		extent: w fullBounds extent + 2.
