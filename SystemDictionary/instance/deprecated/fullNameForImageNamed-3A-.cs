fullNameForImageNamed: aName

	| newName |
	self deprecated: 'Use SmalltalkImage current fullNameForImageNamed: aName'.
	newName _ FileDirectory baseNameFor: (FileDirectory default fullNameFor: aName).
	^newName , FileDirectory dot, FileDirectory imageSuffix.