packages
	"Lazily maintain a cache of all known package objects."

	packages ifNotNil: [^packages].
	objects ifNil: [^#()].
	packages := objects select: [:o | o isPackage].
	^packages