sortedKeysForMessages: aSet 
	"use a heuristic to choose method of obtaining sorted message list"
	^ aSet size * (aSet size log: 2) * 3 > indexFile keysCount
		ifTrue: [indexFile keys select: [:msgID | "indexFile keys is sorted"
				aSet includes: msgID]]
		ifFalse: [(aSet asArray
				mergeSortFrom: 1
				to: aSet size
				by: [:a :b | (self getTOCentry: a) time < (self getTOCentry: b) time]) asOrderedCollection]