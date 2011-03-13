savePackageList
	packageListFilename ifNotNil: [
		UPackage savePackageList: universe packages onFileNamed: packageListFilename ]