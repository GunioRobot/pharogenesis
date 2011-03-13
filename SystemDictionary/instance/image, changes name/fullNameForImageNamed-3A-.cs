fullNameForImageNamed: aName
	| newName |
	newName _ FileDirectory baseNameFor: aName asFileName.
	^newName , FileDirectory dot, FileDirectory imageSuffix.