rule3b
	"A phrase-final postvocalic liquid or nasal is lengthened by 140"

	phrase lastSyllable events do: [ :each | (each phoneme isNasal or: [each phoneme isLiquid]) ifTrue: [each stretch: 1.4]]