testEmpty
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'}.
