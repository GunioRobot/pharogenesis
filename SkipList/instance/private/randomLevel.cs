randomLevel
	| p answer max |
	p _ 0.5.
	answer _ 1.
	max _ self maxLevel.
	[Rand next < p and: [answer < max]]
		whileTrue: [answer _ answer + 1].
	^ answer