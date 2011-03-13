installedVersionOfPackageWithId: anId
	"If the package is installed, return the automatic version or version String.
	Otherwise return nil. This can be used without the map loaded."

	^self registry installedVersionOfPackageWithId: anId