gcd: anInteger 
	"Answer the greatest common divisor of the receiver and n. Uses Roland 
	Silver's algorithm (see Knuth, Vol. 2). Fixed by Andres Valloud to allow
	zero arguments, 01/02/98"

	| m n d t |
	m _ self abs max: anInteger abs.
	(n _ self abs min: anInteger abs) = 0 ifTrue: [^m].
	"Fix: if the smaller argument is zero, answer the other"
	m \\ n = 0 ifTrue: [^n].
	"easy test, speeds up rest"
	d _ 0.
	[n even and: [m even]]
		whileTrue: 
			[d _ d + 1.
			n _ n bitShift: -1.
			m _ m bitShift: -1].
	[n even]
		whileTrue: [n _ n bitShift: -1].
	[m even]
		whileTrue: [m _ m bitShift: -1].
	[m = n]
		whileFalse: 
			[m > n
				ifTrue: 
					[m _ m - n]
				ifFalse: 
					[t _ m.
					m _ n - m.
					n _ t].
			"Make sure larger gets replaced"
			[m even]
				whileTrue: [m _ m bitShift: -1]].
	d = 0 ifTrue: [^m].
	^m bitShift: d