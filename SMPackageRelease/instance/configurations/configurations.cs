configurations
	"Return all SMPackageReleaseConfigurations attached to this release."


	^ self embeddedResources select: [:er | er isConfiguration]