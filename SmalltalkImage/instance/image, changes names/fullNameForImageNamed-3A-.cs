fullNameForImageNamed: aName

	| imgDir newName |
	imgDir := FileDirectory on: self imagePath.
	newName := FileDirectory baseNameFor: (imgDir fullNameFor: aName).
	^newName , FileDirectory dot, FileDirectory imageSuffix.