packageCacheDirectory
	"Return a FileDirectory for the package cache of the map.
	Creates it if it is missing."

	| dirName baseDir |
	dirName _ self packageCacheDirectoryName.
	baseDir _ self directory.
	(baseDir fileOrDirectoryExists: dirName)
		ifFalse:[baseDir createDirectory: dirName].
	^baseDir directoryNamed: dirName