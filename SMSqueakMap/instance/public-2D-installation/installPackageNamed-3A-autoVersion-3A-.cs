installPackageNamed: aString autoVersion: version
	"Install the release <version> of the package with a name
	beginning with aString (see method comment
	of #packageWithNameBeginning:). <version> is the
	automatic version name."

	| p r |
	p := self packageWithNameBeginning: aString.
	p ifNil: [self error: 'No package found with name beginning with ', aString].
	r := p releaseWithAutomaticVersionString: version.
	r ifNil: [self error: 'No package release found with automatic version ', version].
	^self installPackageRelease: r