recategorizeAll: aCollection as: categoryName
	(self oppositeCategoryOf: categoryName) removeAllFoundIn: aCollection.
	(self categoryNamed: categoryName) addAll: aCollection.
