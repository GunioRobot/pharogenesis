sourceMap
	"Answer with a sorted set of associations (pc range)."

	| key |
	^(sourceRanges keys collect: 
		[:key |  Association key: key pc value: (sourceRanges at: key)])
			asSortedCollection