emphasizeScanner: scanner

	anchoredMorph ifNil: [^self].
	(anchoredMorph owner isKindOf: TextPlusPasteUpMorph) ifFalse: [^anchoredMorph _ nil].
	"follwing has been removed - there was no implementation for it"
	"scanner setYFor: anchoredMorph"

