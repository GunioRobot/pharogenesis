fullNameForChangesNamed: aName

	| newName |
	self deprecated: 'Use SmalltalkImage current fullNameForChangesNamed: aName'.
	newName _ FileDirectory baseNameFor: (FileDirectory default fullNameFor: aName).
	^newName , FileDirectory dot, FileDirectory changeSuffix.