testFilingIntoNonexistentCategory
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'}.
	categorizer file: 192 inCategory: 'kumquat'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'kumquat'}.
	self assert: (categorizer at: 'kumquat') asSortedCollection asArray = {192}.
