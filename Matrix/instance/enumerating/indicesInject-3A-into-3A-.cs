indicesInject: start into: aBlock
	|current|

	current _ start.
	1 to: nrows do: [:row |
		1 to: ncols do: [:column |
			current _ aBlock value: current value: row value: column]].
	^current