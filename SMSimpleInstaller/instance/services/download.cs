download
	"This service downloads the last release of the package
	even if it is in the cache already."

	packageRelease download ifTrue: [
		fileName _ packageRelease downloadFileName.
		dir _ packageRelease cacheDirectory]