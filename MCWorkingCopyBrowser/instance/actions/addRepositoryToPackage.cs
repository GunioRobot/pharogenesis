addRepositoryToPackage
	self repository ifNotNilDo:
		[:repos |
		(self pickWorkingCopySatisfying: [ :p | (p repositoryGroup includes: repos) not ]) ifNotNilDo:
			[:wc |
			workingCopy := wc.
			workingCopy repositoryGroup addRepository: repos.
			self repository: repos.	
			self
				changed: #workingCopySelection;
				changed: #repositoryList;
				changed: #repositorySelection.
			self changedButtons]]