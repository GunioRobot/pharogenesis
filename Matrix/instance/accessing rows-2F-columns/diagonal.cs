diagonal
	"Answer (1 to: (nrows min: ncols)) collect: [:i | self at: i at: i]"
	|i|

	i _ ncols negated.
	^(1 to: (nrows min: ncols)) collect: [:j | contents at: (i _ i + ncols + 1)]