imagePath
	"Answer the path for the directory containing the image file."
	"Smalltalk imagePath"

	^ FileDirectory
		splitName: self imageName
		to: [ :volName :fileName | ^ volName ]