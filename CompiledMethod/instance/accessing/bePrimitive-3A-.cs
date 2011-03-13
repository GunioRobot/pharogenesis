bePrimitive: primitiveIndex 
	"Used in conjunction with simulator only"
	self objectAt: 1
		put: ((self objectAt: 1) bitAnd: 16rFFFFFE00) + primitiveIndex