importImage
	"Import the given image file and store the resulting Form in the global dictionary
	ImageImports, at a key consisting of the short filename up to the first period.  "
	| key image |
	key _ fileName sansPeriodSuffix.
	image _ Form fromFileNamed: self fullName.
	Smalltalk imageImports at: key put: image.
