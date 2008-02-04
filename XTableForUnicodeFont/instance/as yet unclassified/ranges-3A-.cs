ranges: pairArray

	xTables := Array new: 0.
	pairArray do: [:range |
		xTables := xTables copyWith: (Array new: range last - range first + 1 withAll: 0).
	].
	ranges := pairArray.
