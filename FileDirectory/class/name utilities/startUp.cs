startUp
	"Establish the platform-specific FileDirectory subclass. Do any platform-specific startup."
	self setDefaultDirectoryClass.

	self setDefaultDirectory: (self dirPathFor: SmalltalkImage current imageName).

	Preferences startInUntrustedDirectory 
		ifTrue:[	"The SecurityManager may override the default directory to prevent unwanted write access etc."
				self setDefaultDirectory: SecurityManager default untrustedUserDirectory.
				"Make sure we have a place to go to"
				DefaultDirectory assureExistence].
	SmalltalkImage current openSourceFiles.
