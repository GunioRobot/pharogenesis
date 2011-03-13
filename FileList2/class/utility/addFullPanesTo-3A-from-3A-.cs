addFullPanesTo: window from: aCollection

	| frame |

	aCollection do: [ :each |
		frame _ LayoutFrame 
			fractions: each second 
			offsets: each third.
		window addMorph: each first fullFrame: frame.
	]