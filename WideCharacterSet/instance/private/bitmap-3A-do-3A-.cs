bitmap: aMap do: aBlock
	"Execute a block with each value (0 based) corresponding to set bits"
	
	0 to: 31 do: [:shift |
		| mask |
		mask := 1 bitShift: shift.
		1 to: aMap size do: [:i | 
			((aMap at: i) bitAnd: mask) isZero ifFalse: [aBlock value: ((i - 1 bitShift: 5) bitOr: shift)]]]