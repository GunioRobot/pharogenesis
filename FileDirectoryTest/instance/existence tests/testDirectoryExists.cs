testDirectoryExists

	self assert: self myAssuredDirectory exists.
	self should: [self myDirectory containingDirectory 
					directoryExists: self myLocalDirectoryName].

	self myDirectory containingDirectory deleteDirectory: self myLocalDirectoryName.
	self shouldnt: [self myDirectory containingDirectory 
						directoryExists: self myLocalDirectoryName]