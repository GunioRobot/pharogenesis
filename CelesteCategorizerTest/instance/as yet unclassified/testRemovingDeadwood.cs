testRemovingDeadwood
	| mockIndexFile |
	categorizer file: 1 inCategory: 'qwerty'.
	categorizer file: 2 inCategory: 'qwerty'.
	categorizer file: 3 inCategory: 'qwerty'.
	categorizer file: 4 inCategory: 'qwerty'.
	categorizer file: 5 inCategory: 'qwerty'.
	mockIndexFile _ Dictionary newFrom: {1 -> 'one'. 3 -> 'three'. 4 -> 'four'. 6 -> 'six'}.
	categorizer removeAllSuchThat: [:i | (mockIndexFile keys includes: i) not].
	self assert: (categorizer at: 'qwerty') asSortedCollection asArray = {1. 3. 4}.