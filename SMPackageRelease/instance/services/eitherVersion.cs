eitherVersion
	"Return either version:
		1. If the maintainer entered a version then we use that.
		2. Otherwise we use the automatic version with an 'r' prepended."

	^version notEmpty
			ifTrue:[version]
			ifFalse:['r', automaticVersion versionString]