emphasizeScanner: scanner

	anchoredMorph ifNil: [^self].
	(anchoredMorph owner isKindOf: TextPlusPasteUpMorph) ifFalse: [^anchoredMorph _ nil].
	scanner setYFor: anchoredMorph

