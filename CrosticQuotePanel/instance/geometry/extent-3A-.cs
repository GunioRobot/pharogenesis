extent: newExtent

	| w h nAcross relLoc topLeft |
	w _ self firstSubmorph width - 1.  h _ self firstSubmorph height - 1.
	nAcross _ newExtent x - (self borderWidth-1*2)-1 // w.
	topLeft _ self position + self borderWidth - 1.
	submorphs withIndexDo:
		[:m :i | 
		relLoc _ (i-1 \\ nAcross * w) @ (i-1 // nAcross * h).
		m position: topLeft + relLoc].
	super extent: ((w * nAcross + 1) @ (submorphs size - 1 // nAcross + 1 * h+1))
					+ (self borderWidth - 1 * 2).
