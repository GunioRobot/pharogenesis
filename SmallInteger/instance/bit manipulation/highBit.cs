highBit
	"Answer the index of the high order bit of the receiver, or zero if the receiver is zero. Raise an error if the receiver is negative, since negative integers are defined to have an infinite number of leading 1's in 2's-complement arithmetic."

	| shifted bitNo |
	self < 0 ifTrue: [self error: 'highBit is not defined for negative integers'].
	shifted _ self.
	bitNo _ 0.
	[shifted < 16] whileFalse:
		[shifted _ shifted bitShift: -4.
		bitNo _ bitNo + 4].
	[shifted = 0] whileFalse:
		[shifted _ shifted bitShift: -1.
		bitNo _ bitNo + 1].
	^ bitNo
