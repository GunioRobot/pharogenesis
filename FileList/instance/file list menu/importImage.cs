importImage
	"Import the selected file and store the resulting Form or ColorForm in the global dictionary GIFImports, at a key consisting of the short filename up to the first period."

	| ff |
	ff _ Form fromFile: (directory oldFileNamed: fileName).
	Smalltalk gifImports at: (fileName sansPeriodSuffix) put: ff.
