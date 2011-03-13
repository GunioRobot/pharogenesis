removeOlderReleasesIn: collectionOfReleases
	"Remove older multiple releases of the same package.
	2 scans to retain order."

	| newestReleases rel |
	newestReleases := Dictionary new.
	collectionOfReleases do: [:r |
		rel := newestReleases at: r package ifAbsent: [newestReleases at: r package put: r].
		(r newerThan: rel) ifTrue: [newestReleases at: r package put: r]].
	^collectionOfReleases select: [:r |
		(newestReleases at: r package) == r]