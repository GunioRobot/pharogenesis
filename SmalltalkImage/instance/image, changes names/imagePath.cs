imagePath
	"Answer the path for the directory containing the image file."
	"SmalltalkImage current imagePath"

	^ FileDirectory dirPathFor: self imageName
