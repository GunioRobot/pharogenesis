dominantColor
	| tally max maxi |
	depth > 16 ifTrue:
		[^(self asFormOfDepth: 16) dominantColor].
	tally _ self tallyPixelValues.
	max _ maxi _ 0.
	tally withIndexDo: [:n :i | n > max ifTrue: [max _ n. maxi _ i]].
	^ Color colorFromPixelValue: maxi - 1 depth: depth