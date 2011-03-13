randomLevel
	| p answer max |
	p := 0.5.
	answer := 1.
	max := self maxLevel.
	[Rand next < p and: [answer < max]]
		whileTrue: [answer := answer + 1].
	^ answer