testAddingAndRemovingCategories
	categorizer addCategory: 'aardvark'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'aardvark'}.
	self assert: (categorizer at: 'aardvark') isEmpty.
	categorizer addCategory: 'banana'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'aardvark'. 'banana'}.
	categorizer removeCategory: 'aardvark'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'banana'}.

	"If I try to add one that already exists, it shouldn't do anything."
	categorizer addCategory: 'banana'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'banana'}.

	"I shouldn't be allowed to remove the pseudo-categories, either."
	categorizer removeCategory: '.all.'.
	self assert: categorizer allCategories asSortedCollection asArray = {'.all.'. '.unclassified.'. 'banana'}.
