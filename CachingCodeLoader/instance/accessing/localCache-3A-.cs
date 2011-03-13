localCache: stringArray
	| fd |
	fd _ FileDirectory default.
	stringArray do:[:part|
		(fd directoryNames includes: part) 
			ifFalse:[fd createDirectory: part].
		fd _ fd directoryNamed: part].
	self cacheDir: (fd pathName copyWith: fd pathNameDelimiter).