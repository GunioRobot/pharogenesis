installPackage: aPackage autoVersion: version
	"Install the release <version> of <aPackage.
	<version> is the automatic version name."

	| r |
	r _ aPackage releaseWithAutomaticVersionString: version.
	r ifNil: [self error: 'No package release found with automatic version ', version].
	^self installPackageRelease: r