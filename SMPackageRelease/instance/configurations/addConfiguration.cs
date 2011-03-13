addConfiguration
	"Create and add a new SMPackageReleaseConfiguration and return it."

	^ self addResource: (SMPackageReleaseConfiguration newIn: map)