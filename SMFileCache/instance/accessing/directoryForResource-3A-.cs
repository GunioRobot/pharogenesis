directoryForResource: aResource
	"Returns the local path for storing the package cache's version of a  
	resource file. This also ensures that the path exists."

	| slash path dir |
	slash _ FileDirectory slash.
	path _ 'resources' , slash , aResource id asString36.
	dir _ FileDirectory default on: self directory fullName, slash, path.
	dir assureExistence.
	^dir