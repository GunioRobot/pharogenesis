installPackageReleaseWithId: anUUIDString
	"Look up and install the given release."

	| r |
	r _ self packageReleaseWithId: anUUIDString.
	r ifNil: [self error: 'No package release available with id: ''', anUUIDString, ''''].
	^self installPackageRelease: r