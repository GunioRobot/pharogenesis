decompress
	super decompress.
	activeMorphs _ activeMorphs asSortedCollection: [:a :b | a depth > b depth]