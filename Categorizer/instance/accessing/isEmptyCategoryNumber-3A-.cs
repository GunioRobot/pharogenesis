isEmptyCategoryNumber: anInteger

	| firstIndex lastIndex |
	(anInteger < 1 or: [anInteger > categoryStops size])
		ifTrue: [^ true].
	firstIndex _ self firstIndexOfCategoryNumber: anInteger.
	lastIndex _  self lastIndexOfCategoryNumber: anInteger.
	^ firstIndex > lastIndex