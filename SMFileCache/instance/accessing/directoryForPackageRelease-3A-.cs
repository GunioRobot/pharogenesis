directoryForPackageRelease: aPackageRelease
	"Returns the local path for storing the package cache's version of a  
	package file. This also ensures that the path exists."

	| slash path dir |
	slash := FileDirectory slash.
	path := 'packages' , slash , aPackageRelease package id asString36 , slash , aPackageRelease automaticVersionString.
	dir := FileDirectory default on: self directory fullName, slash, path.
	dir assureExistence.
	^dir