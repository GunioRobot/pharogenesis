toggleSystemCategoryListIndex: anInteger 
	"If anInteger is the current system category index, deselect it. Else make 
	it the current system category selection."

	self systemCategoryListIndex: 
		(systemCategoryListIndex = anInteger
			ifTrue: [0]
			ifFalse: [anInteger])