isClosureCompiled: bool
	"Use the sign bit in the header to mark methods that have been compiled using the new closure compiler (Parser2)."

	self objectAt: 1 put: (bool
		ifTrue: [(self header bitOr: 1 << 30) as31BitSmallInt]
		ifFalse: [(self header bitAnd: (1 << 30) bitInvert) as31BitSmallInt])