swapRow: anIndex withRow: anotherIndex
	|a b|

	a := self indexForRow: anIndex andColumn: 1.
	b := self indexForRow: anotherIndex andColumn: 1.
	ncols timesRepeat: [
		contents swap: a with: b.
		a := a + 1.
		b := b + 1].
