isIntegerValue: intValue
	"Return true if the given value can be represented as a Smalltalk integer value."
	"Details: This trick is from Tim Rowledge. Use a shift and XOR to set the sign bit if and only if the top two bits of the given value are the same, then test the sign bit. Note that the top two bits are equal for exactly those integers in the range that can be represented in 31-bits."

	^ (intValue bitXor: (intValue << 1)) >= 0