storeResourceList: collector in: fd
	"Store a list of all used resources in the given directory. Used for maintenance."
	| file rcName |
	rcName _ self resourceDirectoryName,'.rc'.
	file _ fd forceNewFileNamed: rcName.
	collector locatorsDo:[:loc| file nextPutAll: loc urlString; cr].
	file close.
	file _ fd readOnlyFileNamed: rcName.
	file compressFile.
	fd deleteFileNamed: rcName ifAbsent:[].