startUp
	"Establish the platform-specific FileDirectory subclass. Do any platform-specific startup."

	self setDefaultDirectoryFrom: Smalltalk imageName.
	Smalltalk openSourceFiles.
