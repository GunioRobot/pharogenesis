cHighBit: uint 
	"Answer the index of the high order bit of the argument, or zero if the  
	argument is zero."
	| shifted bitNo |
	self var: #shifted declareC: 'unsigned int  shifted'.
	shifted _ uint.
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