testIsUnclassified
	self assert: (categorizer isUnclassified: 1).  "If it's not in there at all, it's certainly unclassified."
	categorizer file: 1 inCategory: 'aardvark'.
	self deny: (categorizer isUnclassified: 1).
	categorizer remove: 1 fromCategory: 'aardvark'.
	self assert: (categorizer isUnclassified: 1).

	"What if we remove the entire category?"
	categorizer file: 2 inCategory: 'aardvark'.
	categorizer file: 3 inCategory: 'aardvark'.
	self deny: (categorizer isUnclassified: 2).
	self deny: (categorizer isUnclassified: 3).
	categorizer removeCategory: 'aardvark'.
	self assert: (categorizer isUnclassified: 2).
	self assert: (categorizer isUnclassified: 3).
