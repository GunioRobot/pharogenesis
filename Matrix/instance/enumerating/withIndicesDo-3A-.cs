withIndicesDo: aBlock
	|i|

	i _ 0.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			aBlock value: (contents at: (i _ i+1)) value: row value: column]].
