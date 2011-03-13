addFullPanesTo: aMorph from: aCollection
	| frame |
	aCollection do: [ :each |
		frame := LayoutFrame 
			fractions: each second 
			offsets: each third.
		aMorph addMorph: each first fullFrame: frame.
	]