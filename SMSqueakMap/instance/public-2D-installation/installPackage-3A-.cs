installPackage: aPackage
	"Install the package.

	Note: This method should not be used anymore, better
	to specify a specific release."

	| rel |
	rel := aPackage lastPublishedReleaseForCurrentSystemVersion
			ifNil: [self error: 'No published release for this system version found to install.'].
	^self installPackageRelease: rel