calculateColumnOffsetsFrom: maxWidths
	| offsets previous current |
	offsets _ Array new: maxWidths size.
	1
		to: offsets size
		do: [:indx | offsets at: indx put: (maxWidths at: indx)
					+ 10].
	2
		to: offsets size
		do: [:indx | 
			previous _ offsets at: indx - 1.
			current _ offsets at: indx.
			current _ previous + current.
			offsets at: indx put: current].
	^offsets
