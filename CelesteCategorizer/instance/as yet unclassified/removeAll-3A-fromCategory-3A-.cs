removeAll: aCollection fromCategory: categoryName
	(categories at: categoryName ifAbsent: [^self]) removeAllFoundIn: aCollection.