testSorting

	| c1 c2 |
	c1 _ self timestampClass current.
	c2 _ self timestampClass current.

	self
		assert: (self timestampClass current) <= (self timestampClass current);
		assert: (c1 <= c2).


