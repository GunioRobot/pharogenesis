highBit   "10 highBit 4"
	"Returns the number of the highest 1-bit.  Note that they
	are numbered with 1248 being 1234 -- NOT zero-based.
	Also note that 0 highBit returns 0"
	| shifted bitNo |
	self < 0 ifTrue: [^ (0 - self) highBit].
	shifted _ self.
	bitNo _ 0.
	[shifted = 0] whileFalse:
		[shifted _ shifted bitShift: -1.
		bitNo _ bitNo + 1].
	^ bitNo
