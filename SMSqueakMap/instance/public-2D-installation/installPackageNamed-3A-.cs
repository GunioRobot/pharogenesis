installPackageNamed: aString
	"Install the last published release
	for this Squeak version of the package with a name
	beginning with aString (see method comment
	of #packageWithNameBeginning:).

	Note: This method should not be used anymore.
	Better to specify a specific release."

	| p |
	p := self packageWithNameBeginning: aString.
	p ifNil: [self error: 'No package found with name beginning with ', aString].
	^self installPackage: p