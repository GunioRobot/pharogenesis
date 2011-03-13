deleteDirectory
	
	(self directory exists) ifTrue:
		[self directory containingDirectory deleteDirectory: self directoryName]