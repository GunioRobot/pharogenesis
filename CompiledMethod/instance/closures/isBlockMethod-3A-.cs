isBlockMethod: bool
	"Use the sign bit in the header to mark methods that are sub-methods of an outer method. The outer method will be held in my last literal."

	self objectAt: 1 put: (bool
		ifTrue: [self header bitOr: 1 << 29]
		ifFalse: [self header bitAnd: (1 << 29) bitInvert])