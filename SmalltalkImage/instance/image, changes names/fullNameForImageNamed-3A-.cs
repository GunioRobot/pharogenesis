fullNameForImageNamed: aName
	| imgDir |
	imgDir := FileDirectory on: self imagePath.
	^FileDirectory fileName: (imgDir fullNameFor: aName) extension: FileDirectory imageSuffix.