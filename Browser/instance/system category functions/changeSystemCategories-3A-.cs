changeSystemCategories: aString 
	"Update the class categories by parsing the argument aString."

	systemOrganizer changeFromString: aString.
	self systemCategoryListIndex: 0.
	self changed: #systemCategoriesChanged.
	^true