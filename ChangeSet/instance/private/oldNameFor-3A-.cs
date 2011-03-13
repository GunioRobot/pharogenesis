oldNameFor: class
	| cName |
	cName _ (classChanges at: class name) asOrderedCollection
				detect: [:x | 'oldName: *' match: x].
	^ (Scanner new scanTokens: cName) last