assert: file1 equalTo: file2
	self assert: file1 allCategories asSortedCollection asArray = file2 allCategories asSortedCollection asArray.
	file1 realCategories do: [ :c | self assert: (file1 at: c) asSortedCollection asArray = (file2 at: c) asSortedCollection asArray].