highBitOfPositiveReceiver
	| shifted bitNo |
	"Answer the index of the high order bit of the receiver, or zero if the 
	receiver is zero. Receiver has to be positive!"
	shifted _ self.
	bitNo _ 0.
	[shifted < 16]
		whileFalse: 
			[shifted _ shifted bitShift: -4.
			bitNo _ bitNo + 4].
	[shifted = 0]
		whileFalse: 
			[shifted _ shifted bitShift: -1.
			bitNo _ bitNo + 1].
	^ bitNo