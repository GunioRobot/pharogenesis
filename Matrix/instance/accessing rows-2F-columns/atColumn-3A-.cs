atColumn: column
	|p|

	p _ (self indexForRow: 1 andColumn: column)-ncols.
	^(1 to: nrows) collect: [:row | contents at: (p _ p+ncols)]
