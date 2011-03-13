isDisjointFrom: anInterval
	"Answer true if anInterval is a caret not touching or within the current
	 interval, or if anInterval is a non-caret that does not overlap the current
	 selection."

	| fudge |
	fudge _ anInterval size = 0 ifTrue: [1] ifFalse: [0].
	^(anInterval last + fudge < startBlock stringIndex or:
			[anInterval first - fudge >= stopBlock stringIndex])
