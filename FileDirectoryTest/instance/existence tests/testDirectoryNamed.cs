testDirectoryNamed

	self should: [(self myDirectory containingDirectory 
					directoryNamed: self myLocalDirectoryName) pathName 
						= self myDirectory pathName]