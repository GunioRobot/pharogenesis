badtestSavingAndReadingLargeFile
	| categories savedCategorizer |
	categories _ {'qwerty'. 'uiop'. 'asdf'. 'ghjkl'. 'zxcv'. 'bnm'}.
	1 to: 5000 do: [:i | categorizer file: i inCategory: categories atRandom].
	[FileDirectory deleteFilePath: 'CategorizerTest.temp'.
	self save: categorizer into: 'CategorizerTest.temp'.
	savedCategorizer _ self readFrom: 'CategorizerTest.temp'.
	self assert: categorizer equalTo: savedCategorizer]
		ensure:
			[FileDirectory deleteFilePath: 'CategorizerTest.temp'].