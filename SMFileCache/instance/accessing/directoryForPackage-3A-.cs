directoryForPackage: aPackage
	"Returns the local path for storing the package cache's package file area.
	This also ensures that the path exists."

	| slash path dir |
	slash := FileDirectory slash.
	path := 'packages' , slash , aPackage id asString36 , slash.
	dir := FileDirectory default on: self directory fullName, slash, path.
	dir assureExistence.
	^dir