ensureExistenceOfCategory: categoryName ifPseudo: pseudoBlock
	^ self ensureExistenceOfCategory: categoryName ifPseudo: pseudoBlock ifNew: [:cat | cat]