withIndicesCollect: aBlock
	|i r|

	i _ 0.
	r _ contents shallowCopy.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			i _ i+1.
			r at: i put: (aBlock value: (r at: i) value: row value: column)]].
	^self class rows: nrows columns: ncols contents: r
