withIndicesInject: start into: aBlock
	|i current|

	i _ 0.
	current _ start.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			current _ aBlock value: current value: (contents at: (i _ i+1)) 
							  value: row value: column]].
	^current