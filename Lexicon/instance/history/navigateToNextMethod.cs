navigateToNextMethod
	"Navigate to the 'next' method in the current viewing sequence"

	| anIndex aSelector |
	self selectorsVisited size == 0 ifTrue: [^ self].
	anIndex _ (aSelector _ self selectedMessageName) notNil ifTrue: [selectorsVisited indexOf: aSelector ifAbsent: [selectorsVisited size]] ifFalse: [1].
	self selectedCategoryName == self class viewedCategoryName 
		ifTrue:
			[self selectWithinCurrentCategory: (selectorsVisited atWrap: (anIndex + 1))]
		ifFalse:
			[self displaySelector: (selectorsVisited atWrap: (anIndex + 1))]