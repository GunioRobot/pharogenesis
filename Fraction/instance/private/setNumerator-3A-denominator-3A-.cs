setNumerator: n denominator: d

	d = 0
		ifTrue: [^(ZeroDivide dividend: n) signal]
		ifFalse: 
			[numerator _ n asInteger.
			denominator _ d asInteger abs. "keep sign in numerator"
			d < 0 ifTrue: [numerator _ numerator negated]]