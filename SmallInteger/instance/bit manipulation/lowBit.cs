lowBit
	" Answer the index of the low order one bit.
		2r00101000 lowBit       (Answers: 4)
		2r-00101000 lowBit      (Answers: 4)
	  First we skip bits in groups of 4, then single bits.
	  While not optimal, this is a good tradeoff; long
	  integer #lowBit always invokes us with bytes."
	| n result last4 |
	n := self.
	n = 0 ifTrue: [ ^ 0 ].
	result := 0.
	[(last4 := n bitAnd: 16rF) = 0]
		whileTrue: [
			result := result + 4.
			n := n bitShift: -4 ].

	"The low bits table can be obtained with:
	(1 to: 4) inject: #[1] into: [:lowBits :rank | (lowBits copy at: 1 put: lowBits first + 1; yourself) , lowBits]."
	^result + ( #[5 1 2 1 3 1 2 1 4 1 2 1 3 1 2 1] at: (last4)+1)