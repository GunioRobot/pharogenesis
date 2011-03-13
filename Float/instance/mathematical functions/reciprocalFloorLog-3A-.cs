reciprocalFloorLog: radix 
	"Quick computation of (self log: radix) floor, when self < 1.0.
	Avoids infinite recursion problems with denormalized numbers"

	| adjust scale n |
	adjust _ 0.
	scale _ 1.0.
	[(n _ radix / (self * scale)) isInfinite]
		whileTrue:
			[scale _ scale * radix.
			adjust _ adjust + 1].
	^ ((n floorLog: radix) + adjust) negated