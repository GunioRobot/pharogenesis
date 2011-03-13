installedVersionOf: aPackage
	"If the package is installed, return the version as a String.
	If it is a package installed during SM1 it will return the manual version String,
	for SM2 it returns the automatic version as a String.
	If package is not installed - return nil. If you want it to work without the map loaded you
	should instead use #installedVersionOfPackageWithId:."

	^self registry installedVersionOf: aPackage