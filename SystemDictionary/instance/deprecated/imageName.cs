imageName
	"Answer the full path name for the current image."
	"Smalltalk imageName"

	^ self deprecated: 'Use SmalltalkImage current imageName'
		block: [SmalltalkImage current imageName]