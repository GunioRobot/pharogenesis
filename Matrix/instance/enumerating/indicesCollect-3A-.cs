indicesCollect: aBlock
	|r i|

	r := Array new: nrows * ncols.
	i := 0.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			r at: (i := i+1) put: (aBlock value: row value: column)]].
	^self class rows: nrows columns: ncols contents: r