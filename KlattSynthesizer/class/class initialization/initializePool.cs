initializePool
	| dict |
	(Smalltalk includesKey: #KlattResonatorIndices)
		ifFalse: [Smalltalk declare: #KlattResonatorIndices from: Undeclared].
	(Smalltalk at: #KlattResonatorIndices) isNil
		ifTrue: [(Smalltalk associationAt: #KlattResonatorIndices) value: Dictionary new].
	dict _ Smalltalk at: #KlattResonatorIndices.
	#(Rnpp Rtpp R1vp R2vp R3vp R4vp R2fp R3fp R4fp R5fp R6fp R1c R2c R3c R4c R5c R6c R7c R8c Rnpc Rnz Rtpc Rtz Rout)
		doWithIndex: [ :each :i | dict at: each asSymbol put: i]