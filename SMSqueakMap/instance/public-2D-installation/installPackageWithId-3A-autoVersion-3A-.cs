installPackageWithId: anUUIDString autoVersion: version
	"Install the release <version> of the package with id <anUUIDString>.
	<version> is the automatic version name."

	| p |
	p := self packageWithId: anUUIDString.
	p ifNil: [self error: 'No package available with id: ''', anUUIDString, ''''].
	^self installPackage: p autoVersion: version