testExists

	self should: [FileDirectory default exists]
		description: 'Should know default directory exists.'.
	self should: [self myAssuredDirectory exists]
		description: 'Should know created directory exists.'.

	self myDirectory containingDirectory deleteDirectory: self myLocalDirectoryName.
	self shouldnt: [(self myDirectory containingDirectory directoryNamed: self myLocalDirectoryName) exists]
		description: 'Should know that recently deleted directory no longer exists.'.