assureExtension
	"creates an extension for the receiver if needed"
	self hasExtension
		ifFalse: [self initializeExtension].
	^ self extension