previousReleaseFor: aPackageRelease
	"If there is none, return nil."
	
	^releases before: aPackageRelease ifAbsent: [nil]