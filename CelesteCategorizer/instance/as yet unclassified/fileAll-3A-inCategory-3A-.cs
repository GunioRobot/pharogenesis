fileAll: aCollection inCategory: categoryName 
	(self ensureExistenceOfCategory: categoryName ifPseudo: [^self]) addAll: aCollection.
