deleteDirectory
	
	(self myDirectory exists) ifTrue:
		[self myDirectory containingDirectory deleteDirectory: self myLocalDirectoryName]