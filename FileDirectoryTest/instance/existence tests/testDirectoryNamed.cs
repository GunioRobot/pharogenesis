testDirectoryNamed

	self should: [(self directory containingDirectory 
					directoryNamed: self directoryName) pathName 
						= self directory pathName]