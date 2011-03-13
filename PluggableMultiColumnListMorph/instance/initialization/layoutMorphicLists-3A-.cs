layoutMorphicLists: arrayOfMorphs 
	| maxWidths offsets locs h |
	maxWidths _ self calculateColumnWidthsFrom: arrayOfMorphs.
	offsets _ self calculateColumnOffsetsFrom: maxWidths.
	locs _ Array new: arrayOfMorphs size.
	locs at: 1 put: 0 @ 0.
	2
		to: locs size
		do: [:indx | locs at: indx put: (offsets at: indx - 1)
					@ 0].
	h _ arrayOfMorphs first first height.
	1
		to: arrayOfMorphs size
		do: [:indx | (arrayOfMorphs at: indx)
				do: [:morphItem | 
					morphItem
						bounds: ((locs at: indx)
								extent: 9999 @ h).
					locs at: indx put: (locs at: indx)
							+ (0 @ h)]]