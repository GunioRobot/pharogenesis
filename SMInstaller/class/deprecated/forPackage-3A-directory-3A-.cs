forPackage: aPackage directory: aDirectory
	"Deprecated. Kept for backwards compatibility. Installing
	a package means installing the latest available release."

	self deprecated: 'Method Deprecated: Use SMInstaller>>forPackageRelease: instead. A directory is not needed in SM2, it has its own cache.'.
	^self forPackageRelease: aPackage lastRelease