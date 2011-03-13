isBlockMethod
	"Is this a sub-method (embedded block's method) of another method. If so the last literal points to its outer method"

	^ (self header bitAnd: 1 << 29) ~= 0