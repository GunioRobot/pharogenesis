platformDirectory
	"return the directory where we should find the platform specific sources"
	| fd platNm |
	fd _ self platformRootDirectory.
	(fd directoryExists: (platNm _ self platformName))
		ifFalse: ["The supposed directory for the actual platform code  
			does not exist."
			^ self couldNotFindPlatformDirectoryFor: platNm].
	^ fd directoryNamed: platNm