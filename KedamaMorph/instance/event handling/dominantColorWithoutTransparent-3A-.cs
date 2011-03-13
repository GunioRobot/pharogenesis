dominantColorWithoutTransparent: aForm
	| tally max maxi |
	aForm depth > 16 ifTrue:
		[^self dominantColorWithoutTransparent: (aForm asFormOfDepth: 16)].
	tally _ aForm tallyPixelValues.
	max _ maxi _ 0.
	tally withIndexDo: [:n :i | n > max ifTrue: [ i ~= 1 ifTrue: [max _ n. maxi _ i]]].
	^ Color colorFromPixelValue: maxi - 1 depth: aForm depth
