newPackageWithId: anIdString 
	"Create a package and add it to me.
	Clear the packages cache."

	packages _ nil.
	^self newObject: (SMPackage newIn: self withId: anIdString)