copyPackagesFromWaitingFolderToHomeRepository
	"self defaultMCWaitingFolder allFileNames"
	"self new copyPackageFromWaitingFolderToHomeRepository"
	
	| version |
	self waitingFolderMCZFiles do: [:name |
		version := self class defaultMCWaitingFolder versionFromFileNamed: name.
		self repository storeVersion: version]