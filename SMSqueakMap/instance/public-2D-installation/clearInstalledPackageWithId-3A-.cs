clearInstalledPackageWithId: aPackageId
	"Clear the fact that any release of this package is installed.
	Can be used even when the map isn't loaded."

	^self registry clearInstalledPackageWithId: aPackageId