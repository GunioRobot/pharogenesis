loadBitBltCombinationRule
	"Load the combination rule from a BitBlt oop"
	self inline: true.
	combinationRule _ interpreterProxy fetchInteger: BBRuleIndex ofObject: bitBltOop.
	(interpreterProxy failed
		or: [combinationRule < 0 or: [combinationRule > (OpTableSize - 2)]])
		 ifTrue: [^ false  "operation out of range"].
	(combinationRule >= 16 and: [combinationRule <= 17])
		 ifTrue: [^ false  "fail for old simulated paint, erase modes"].
	^true