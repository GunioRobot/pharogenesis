detectConflictingReleasesIn: collectionOfReleases
	"Detect if the Set has multiple releases of the same package."

	| detectedPackages |
	detectedPackages := Set new.
	collectionOfReleases do: [:r |
		(detectedPackages includes: r package)
			ifTrue: [^ true]
			ifFalse: [detectedPackages add: r package]].
	^false