fileReaderServicesForDirectory: aFileDirectory
	^{
		self serviceImageImportDirectory.
		self serviceImageImportDirectoryWithSubdirectories.
	}