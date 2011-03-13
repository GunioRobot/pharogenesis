gcd: anInteger 
	"See SmallInteger (Integer) | gcd:"
	| n m |
	n _ self.
	m _ anInteger.
	[n = 0]
		whileFalse: 
			[n _ m \\ (m _ n)].
	^ m abs