directoryForPackage: aPackage
	"Returns the local path for storing the package cache's package file area.
	This also ensures that the path exists."

	| slash path dir |
	slash _ FileDirectory slash.
	path _ 'packages' , slash , aPackage id asString36 , slash.
	dir _ FileDirectory default on: self directory fullName, slash, path.
	dir assureExistence.
	^dir