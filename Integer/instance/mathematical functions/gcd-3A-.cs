gcd: anInteger
	"See Knuth, Vol 2, 4.5.2, Algorithm L"
	"Initialize"
	| higher u v k uHat vHat a b c d vPrime vPrimePrime q t |
	higher _ SmallInteger maxVal highBit.
	u _ self abs max: (v _ anInteger abs).
	v _ self abs min: v.
	[u class == SmallInteger]
		whileFalse: 
			[(uHat _ u bitShift: (k _ higher - u highBit)) class == SmallInteger
				ifFalse: 
					[k _ k - 1.
					uHat _ uHat bitShift: -1].
			vHat _ v bitShift: k.
			a _ 1.
			b _ 0.
			c _ 0.
			d _ 1.
			"Test quotient"
			[(vPrime _ vHat + d) ~= 0
				and: [(vPrimePrime _ vHat + c) ~= 0 and: [(q _ uHat + a // vPrimePrime) = (uHat + b // vPrime)]]]
				whileTrue: 
					["Emulate Euclid"
					c _ a - (q * (a _ c)).
					d _ b - (q * (b _ d)).
					vHat _ uHat - (q * (uHat _ vHat))].
			"Multiprecision step"
			b = 0
				ifTrue: 
					[v _ u rem: (u _ v)]
				ifFalse: 
					[t _ u * a + (v * b).
					v _ u * c + (v * d).
					u _ t]].
	^ u gcd: v