decompress
	super decompress.
	activeMorphs := activeMorphs asSortedCollection: [:a :b | a depth > b depth]