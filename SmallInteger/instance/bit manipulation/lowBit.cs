lowBit
	" Answer the index of the low order one bit.
		2r00101000 lowBit       (Answers: 4)
		2r-00101000 lowBit      (Answers: 4)
	  First we skip bits in groups of 4, then single bits.
	  While not optimal, this is a good tradeoff; long
	  integer #lowBit always invokes us with bytes."
	| n result |
	n := self.
	n = 0 ifTrue: [ ^ 0 ].
	result := 1.
	[ (n bitAnd: 16rF) = 0 ]
		whileTrue: [
			result := result + 4.
			n := n bitShift: -4 ].
	[ (n bitAnd: 1) = 0 ]
		whileTrue: [
			result := result + 1.
			n := n bitShift: -1 ].
	^ result