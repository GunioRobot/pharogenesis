firstIndexForInserting: xValue
	"Return the first possible index for inserting an object with the given xValue"
	| index |
	index _ self indexForInserting: xValue.
	[index > 1 and:[(array at: index-1) xValue = xValue]]
		whileTrue:[index _ index-1].
	^index