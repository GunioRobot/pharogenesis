fullNameForImageNamed: aName

	| newName |
	newName := FileDirectory baseNameFor: (FileDirectory default fullNameFor: aName).
	^newName , FileDirectory dot, FileDirectory imageSuffix.