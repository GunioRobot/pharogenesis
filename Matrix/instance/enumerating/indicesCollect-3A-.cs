indicesCollect: aBlock
	|r i|

	r _ Array new: nrows * ncols.
	i _ 0.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			r at: (i _ i+1) put: (aBlock value: row value: column)]].
	^self class rows: nrows columns: ncols contents: r