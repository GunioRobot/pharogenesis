ensureExistenceOfCategory: categoryName
	^ self ensureExistenceOfCategory: categoryName ifPseudo: [self error: 'pseudo category']