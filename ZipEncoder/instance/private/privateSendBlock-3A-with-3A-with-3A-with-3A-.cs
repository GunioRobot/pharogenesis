privateSendBlock: literalStream with: distanceStream with: litTree with: distTree
	"Send the current block using the encodings from the given literal/length and distance tree"
	| lit dist code extra sum |
	<primitive:'primitiveZipSendBlock'>
	sum _ 0.
	[lit _ literalStream next.
	dist _ distanceStream next.
	lit == nil] whileFalse:[
		dist = 0 ifTrue:["lit is a literal"
			sum _ sum + 1.
			self nextBits: (litTree bitLengthAt: lit)
				put: (litTree codeAt: lit).
		] ifFalse:["lit is match length"
			sum _ sum + lit + MinMatch.
			code _ (MatchLengthCodes at: lit + 1).
			self nextBits: (litTree bitLengthAt: code)
				put: (litTree codeAt: code).
			extra _ ExtraLengthBits at: code-NumLiterals.
			extra = 0 ifFalse:[
				lit _ lit - (BaseLength at: code-NumLiterals).
				self nextBits: extra put: lit.
			].
			dist _ dist - 1.
			dist < 256
				ifTrue:[code _ DistanceCodes at: dist + 1]
				ifFalse:[code _ DistanceCodes at: 257 + (dist bitShift: -7)].
			"self assert:[code < MaxDistCodes]."
			self nextBits: (distTree bitLengthAt: code)
				put: (distTree codeAt: code).
			extra _ ExtraDistanceBits at: code+1.
			extra = 0 ifFalse:[
				dist _ dist - (BaseDistance at: code+1).
				self nextBits: extra put: dist.
			].
		].
	].
	^sum