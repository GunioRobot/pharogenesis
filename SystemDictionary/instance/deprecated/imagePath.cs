imagePath
	"Answer the path for the directory containing the image file."
	"Smalltalk imagePath"

	self deprecated: 'Use SmalltalkImage current imagePath'.
	^ FileDirectory dirPathFor: SmalltalkImage current imageName
