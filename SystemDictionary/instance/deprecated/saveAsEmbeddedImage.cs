saveAsEmbeddedImage
	"Save the current state of the system as an embedded image"

	^ self deprecated: 'Use SmalltalkImage current saveAsEmbeddedImage'
		block: [SmalltalkImage current saveAsEmbeddedImage]
