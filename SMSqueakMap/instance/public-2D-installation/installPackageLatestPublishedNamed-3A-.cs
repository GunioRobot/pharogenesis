installPackageLatestPublishedNamed: aString
	"Install the latest published release of the package with a name
	beginning with aString (see method comment
	of #packageWithNameBeginning:)."

	| p |
	p _ self packageWithNameBeginning: aString.
	p ifNil: [self error: 'No package found with name beginning with ', aString].
	^self installPackageLatestPublished: p