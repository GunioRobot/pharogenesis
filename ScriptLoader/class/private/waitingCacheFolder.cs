waitingCacheFolder
	^ (FileDirectory default directoryNamed: self packageToBeTestedFolderName)
		assureExistence;
		yourself

	