closestColor8old
	"Return the nearest approximation to this color for an 8-bit deep Form."

	| bIndex p n |
	self isGray ifTrue: [
		"select nearest gray"
		p _ GrayToIndexMap at: (self privateBlue >> 2) + 1.
	] ifFalse: [
		"compute nearest entry in the color cube"
		p _ ((((self privateRed    * 5) + HalfComponentMask) // ComponentMask) * 36) +
			 ((((self privateBlue * 5) + HalfComponentMask) // ComponentMask) *  6) +
			 (((self privateGreen    * 5) + HalfComponentMask) // ComponentMask) + 40.
	].
	^ (p bitShift: 24) bitOr: ((p bitShift: 16) bitOr: ((p bitShift: 8) bitOr: p))