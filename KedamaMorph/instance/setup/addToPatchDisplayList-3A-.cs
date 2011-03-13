addToPatchDisplayList: p

	| a |
	a _ patchesToDisplay copyWithout: p.
	patchesToDisplay _ a copyWith: p.
