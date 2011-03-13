byteAt: index put: aByte

	| d r w |
	d _ (index + 3) // 4.
	r _ (index - 1) \\ 4 + 1.
	w _ (self wordAt: d) bitAnd: ((16rFF<<((4 - r)*8)) bitInvert32).
	w _ w + (aByte<<((4 - r)*8)).
	self basicAt: d put: w.
	^ aByte.
