fullNameForChangesNamed: aName
	| newName |
	newName _ FileDirectory baseNameFor: aName asFileName.
	^newName , FileDirectory dot, FileDirectory changeSuffix.