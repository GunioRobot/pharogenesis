elementCategoryDict
	| dict firstIndex lastIndex |
	elementArray isNil ifTrue: [^ nil].
	dict _ Dictionary new: elementArray size.
	1to: categoryStops size do: [:cat |
		firstIndex _ self firstIndexOfCategoryNumber: cat.
		lastIndex _ self lastIndexOfCategoryNumber: cat.
		firstIndex to: lastIndex do: [:el |
			dict at: (elementArray at: el) put: (categoryArray at: cat)].
	].
	^ dict.