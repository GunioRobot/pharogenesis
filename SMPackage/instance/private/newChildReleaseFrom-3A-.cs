newChildReleaseFrom: aRelease
	"Create a new release."

	^self addRelease: (map newObject: (SMPackageRelease newFromRelease: aRelease package: self))