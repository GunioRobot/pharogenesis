swapColumn: anIndex withColumn: anotherIndex
	|a b|

	a _ self indexForRow: 1 andColumn: anIndex.
	b _ self indexForRow: 1 andColumn: anotherIndex.
	nrows timesRepeat: [
		contents swap: a with: b.
		a _ a + ncols.
		b _ b + ncols].
