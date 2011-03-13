installedPackagesDictionary
	"Access the dictionary directly. The UUID of the installed package is the key.
	The value is an OrderedCollection of Arrays.
	The arrays have the smartVersion of the package, the time of the
	installation in seconds and the sequence number (installCounter)."

	^installedPackages ifNil: [Dictionary new]