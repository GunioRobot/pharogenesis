packageReleaseWithId: anIdString 
	"Look up a package release. Return nil if missing.
	Raise error if it is not a package release."

	| r |
	r := self objectWithId: anIdString.
	r ifNil: [^nil].
	r isPackageRelease ifTrue:[^r].
	self error: 'UUID did not map to a package release.'