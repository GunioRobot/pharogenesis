digitLshift: shiftCount
	| carry rShift mask len result digit byteShift bitShift highBit |
	(highBit _ self highBit) = 0 ifTrue: [^ 0].
	len _ highBit + shiftCount + 7 // 8.
	result _ Integer new: len neg: self negative.
	byteShift _ shiftCount // 8.
	bitShift _ shiftCount \\ 8.
	bitShift = 0 ifTrue:  
		["Fast version for byte-aligned shifts"
		^ result replaceFrom: byteShift+1 to: len
				with: self startingAt: 1].
	carry _ 0.
	rShift _ bitShift - 8.
	mask _ 255 bitShift: 0 - bitShift.
	1 to: byteShift do: [:i | result digitAt: i put: 0].
	1 to: len - byteShift do: 
		[:i | 
		digit _ self digitAt: i.
		result digitAt: i + byteShift 
			put: (((digit bitAnd: mask) bitShift: bitShift) bitOr: carry).
		carry _ digit bitShift: rShift].
	^ result