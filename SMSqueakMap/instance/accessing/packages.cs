packages
	"Lazily maintain a cache of all known package objects."

	packages ifNotNil: [^packages].
	objects ifNil: [^#()].
	packages _ objects select: [:o | o isPackage].
	^packages