keysForMessages: aSet sortedBy: aBlockOrSymbol
	"If we're sorting by time, it's sometimes faster to just grab the messages in order from the index file."
	^ (aBlockOrSymbol = #time and: [aSet size * (aSet size log: 2) * 3 > indexFile keysCount])
		ifTrue: [indexFile sortedKeys select: [:msgID | aSet includes: msgID]]   "indexFile is already sorted by time"
		ifFalse: [(aSet asArray sort: [:a :b | (aBlockOrSymbol value: (self getTOCentry: a)) < (aBlockOrSymbol value: (self getTOCentry: b))]) asOrderedCollection]