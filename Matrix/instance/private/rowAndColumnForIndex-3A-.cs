rowAndColumnForIndex: index
	|t|

	t _ index - 1.
	^(t // ncols + 1)@(t \\ ncols + 1)