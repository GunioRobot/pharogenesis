testBitLogic  
	"This little suite of tests is designed to verify correct operation of most
	of Squeak's bit manipulation code, including two's complement
	representation of negative values.  It was written in a hurry and
	is probably lacking several important checks."

	"Shift 1 bit left then right and test for 1"
	| n |
	1 to: 100 do: [:i | self should: [((1 bitShift: i) bitShift: i negated) = 1]].

	"Shift -1 left then right and test for 1"
	1 to: 100 do: [:i | self should: [((-1 bitShift: i) bitShift: i negated) = -1]].

	"And a single bit with -1 and test for same value"
	1 to: 100 do: [:i | self should: [((1 bitShift: i) bitAnd: -1) = (1 bitShift: i)]].

	"Verify that (n bitAnd: n negated) = n for single bits"
	1 to: 100 do: [:i | self should: [n _ 1 bitShift: i. (n bitAnd: n negated) = n]].

	"Verify that n negated = (n complemented + 1) for single bits"
	1 to: 100 do: [:i | self should:[n _ 1 bitShift: i.
				n negated = ((n bitXor: -1) + 1)]].

	"Verify that (n + n complemented) = -1 for single bits"
	1 to: 100 do: [:i | self should: [n _ 1 bitShift: i.
				(n + (n bitXor: -1)) = -1]].

	"Verify that n negated = (n complemented +1) for single bits"
	1 to: 100 do: [:i | self should: [n _ 1 bitShift: i.
				n negated = ((n bitXor: -1) + 1)]].

	self should: [(-2 bitAnd: 16rFFFFFFFF) = 16rFFFFFFFE].