byteAt: index

	| d r |
	d _ (index + 3) // 4.
	r _ (index - 1) \\ 4 + 1.
	^ (self wordAt: d) digitAt: ((4 - r) + 1).
