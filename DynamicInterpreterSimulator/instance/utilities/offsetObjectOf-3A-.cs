offsetObjectOf: offsetValue
	"Overridden in the simulator since we can't store negative integers into the memory.
	Note: a bias of 16r20000000 avoids LargeInteger arithmetic."

	self assert: ((offsetValue bitAnd: 1) = 0).
	self assert: (offsetValue < (1024 * 8) and: [offsetValue > (-1024 * 8)]).
	^16r20000000 + offsetValue + 1