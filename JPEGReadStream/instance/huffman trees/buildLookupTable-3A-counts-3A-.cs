buildLookupTable: values counts: counts
	| min max |
	min _ max _ nil.
	1 to: counts size do:[:i|
		(counts at: i) = 0 ifFalse:[
			min ifNil:[min _ i-1].
			max _ i]].
	^self
		createHuffmanTables: values 
		counts: {0},counts 
		from: min+1 
		to: max.