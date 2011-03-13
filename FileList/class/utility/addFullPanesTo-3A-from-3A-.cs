addFullPanesTo: window from: aCollection

	| frame |

	aCollection do: [ :each |
		frame := LayoutFrame 
			fractions: each second 
			offsets: each third.
		window addMorph: each first fullFrame: frame.
	]