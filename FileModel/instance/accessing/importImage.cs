importImage
	"Import the selected file and store the resulting Form or ColorForm in the global dictionary GIFImports, at a key consisting of the short filename up to the first period."

	| f |
	f _ Form fromFileNamed: self fullName.
	f ifNil: [^ self error: 'unrecognized image file format'].
	Smalltalk gifImports at: (self fileName sansPeriodSuffix) put: f.
