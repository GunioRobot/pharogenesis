ranges: pairArray

	xTables _ Array new: 0.
	pairArray do: [:range |
		xTables _ xTables copyWith: (Array new: range last - range first + 1 withAll: 0).
	].
	ranges _ pairArray.
