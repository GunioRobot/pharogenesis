crossPlatformDirectory
	"return the directory where we should find the cross-platform literal 
	sources - <sq.h> etc"
	| fd machDirNm |
	fd _ self platformRootDirectory.
	(fd directoryExists: (machDirNm _ 'Cross'))
		ifFalse: ["The supposed directory for the actual cross-platform code  
			does not exist."
			^ self couldNotFindPlatformDirectoryFor: 'cross-platform '].
	^ fd directoryNamed: machDirNm