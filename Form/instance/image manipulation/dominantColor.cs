dominantColor
	| tally max maxi |
	tally _ self tallyPixelValues.
	max _ maxi _ 0.
	tally withIndexDo: [:n :i | n > max ifTrue: [maxi _ i]].
	^ Color colorFromPixelValue: maxi - 1 depth: depth