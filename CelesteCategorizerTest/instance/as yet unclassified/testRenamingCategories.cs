testRenamingCategories
	categorizer file: 1 inCategory: 'aardvark'.
	categorizer file: 2 inCategory: 'aardvark'.
	categorizer file: 97 inCategory: 'aardvark'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'aardvark'}.
	categorizer renameCategory: 'aardvark' to: 'notaardvark'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'notaardvark'}.
	self assert: (categorizer at: 'notaardvark') asSortedCollection asArray = {1. 2. 97}.