generateSandQ
	"Generate a 160-bit random seed s and an industrial grade prime q."

	| hasher s sPlusOne u q |
	hasher _ SecureHashAlgorithm new.
	[true] whileTrue: [
		s _ self nextRandom160.
		sPlusOne _ s + 1.
		sPlusOne highBit > 160 ifTrue: [sPlusOne _ sPlusOne \\ (2 raisedTo: 160)].
		u _ (hasher hashInteger: s) bitXor: (hasher hashInteger: sPlusOne).
		q _ u bitOr: ((1 bitShift: 159) bitOr: 1).
		(self isProbablyPrime: q) ifTrue: [^ Array with: s with: q]].
