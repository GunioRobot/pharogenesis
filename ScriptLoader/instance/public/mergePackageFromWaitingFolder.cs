mergePackageFromWaitingFolder
	"self defaultMCWaitingFolder allFileNames"
	"self new loadPackageFromWaitingFolder"
	
	| version |
	self waitingFolderMCZFiles
		do: [ :name |
			version := self class defaultMCWaitingFolder  versionFromFileNamed: name.
			version merge.
			]