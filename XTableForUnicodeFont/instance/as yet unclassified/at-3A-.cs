at: indexPlusOne

	| index |
	index := indexPlusOne.
	ranges with: xTables do: [:range :xTable |
		(range first <= index and: [index <= range last]) ifTrue: [
			^ xTable at: index - range first + 1.
		].
	].
	^ 0.
