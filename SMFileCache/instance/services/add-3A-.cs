add: aPackage 
	"Conditionally download the package into the cache.
	Return true on success, otherwise false."

	^(self includes: aPackage)
		ifTrue: [true]
		ifFalse: [self download: aPackage]