swapRow: anIndex withRow: anotherIndex
	|a b|

	a _ self indexForRow: anIndex andColumn: 1.
	b _ self indexForRow: anotherIndex andColumn: 1.
	ncols timesRepeat: [
		contents swap: a with: b.
		a _ a + 1.
		b _ b + 1].
