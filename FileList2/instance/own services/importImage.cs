importImage
	"Import the given image file and store the resulting Form in the default Imports"

	| fname image |
	fname _ fileName sansPeriodSuffix.
	image _ Form fromFileNamed: self fullName.
	Imports default importImage: image named: fname.
