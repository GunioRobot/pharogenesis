imageName: newName
	"Set the the full path name for the current image.  All further snapshots will use this."

	^ self deprecated: 'Use SmalltalkImage current imageName: ', newName
		block: [ SmalltalkImage current imageName: newName ]