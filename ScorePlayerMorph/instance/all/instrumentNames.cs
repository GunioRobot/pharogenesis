instrumentNames
	| names |
	names _ AbstractSound soundNames asOrderedCollection.
	names add: 'clink'.
	names add: 'edit instrument'.
	^ names asArray
