assertCommonAncestorOf: leftName and: rightName is: ancestorName in: tree
	| left right ancestor |
	left _ self versionForName: leftName in: tree.
	right _ self versionForName: rightName in: tree.
	
	ancestor _ left commonAncestorWith: right.
	
	self assert: ancestor name = ancestorName