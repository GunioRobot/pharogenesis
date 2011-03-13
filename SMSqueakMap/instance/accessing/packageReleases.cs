packageReleases
	"Return subset of objects."

	objects ifNil: [^#()].
	^objects select: [:o | o isPackageRelease]