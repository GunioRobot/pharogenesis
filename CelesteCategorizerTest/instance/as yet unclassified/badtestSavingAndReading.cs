badtestSavingAndReading
	| savedCategorizer |
	categorizer file: 37 inCategory: 'aardvark'.
	categorizer file: 42 inCategory: 'aardvark'.
	categorizer file: 678 inCategory: 'banana'.
	categorizer file: 678 inCategory: 'qwerty'.
	categorizer file: 1099 inCategory: 'qwerty'.
	FileDirectory deleteFilePath: 'CategorizerTest.temp'.
	self save: categorizer into: 'CategorizerTest.temp'.
	savedCategorizer _ self readFrom: 'CategorizerTest.temp'.
	self assert: categorizer equalTo: savedCategorizer.
