newRelease
	"Create a new release."

	^releases addLast: (map newObject: (SMPackageRelease newInPackage: self))