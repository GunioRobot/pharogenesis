recomputeType
	| count |
	count _ 0.
	e1 isBorderEdge ifTrue:[count _ count + 1].
	e2 isBorderEdge ifTrue:[count _ count + 1].
	e3 isBorderEdge ifTrue:[count _ count + 1].
	self isJunction: (count = 0).
	self isSleeve: (count = 1).
	self isTerminal: (count = 2).
